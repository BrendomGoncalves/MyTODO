using MediatR;
using mytodo.domain.Entities;
using mytodo.domain.Repository;
using mytodo.domain.Services;
using mytodo.shareable.Excecoes;
using mytodo.shareable.Requests.User;
using mytodo.shareable.Responses.User;
using OperationResult;
using static mytodo.shareable.Enums.Cadastro;

namespace mytodo.domain.Handlers.User;

public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, Result<CreateUserResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEncryptionService _encryptionService;

    public CreateUserRequestHandler(IUserRepository userRepository, IUnitOfWork unitOfWork,
        IEncryptionService encryptionService)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _encryptionService = encryptionService;
    }

    public async Task<Result<CreateUserResponse>> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = new UserEntity
        {
            Username = request.UserName,
            Email = request.Email,
            PasswordHash = _encryptionService.Encrypt(request.PasswordHash),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        try
        {
            await _userRepository.CreateUserAsync(user);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
        catch
        {
            return Result.Error<CreateUserResponse>(new ExcecaoAplicacao(FalhaAoCriar));
        }

        return Result.Success(new CreateUserResponse(user.UserId, user.Username));
    }
}