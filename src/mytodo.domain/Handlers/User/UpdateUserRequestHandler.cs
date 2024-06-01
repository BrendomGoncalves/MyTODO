using MediatR;
using mytodo.domain.Repository;
using mytodo.domain.Services;
using mytodo.shareable.Excecoes;
using mytodo.shareable.Requests.User;
using mytodo.shareable.Responses.User;
using OperationResult;
using static mytodo.shareable.Enums.Cadastro;

namespace mytodo.domain.Handlers.User;

public class UpdateUserRequestHandler : IRequestHandler<UpdateUserRequest, Result<UpdateUserResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEncryptionService _encryptionService;

    public UpdateUserRequestHandler(IUserRepository userRepository, IUnitOfWork unitOfWork,
        IEncryptionService encryptionService)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _encryptionService = encryptionService;
    }

    public async Task<Result<UpdateUserResponse>> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.UserId);

        if (user == null)
        {
            return Result.Error<UpdateUserResponse>(new ExcecaoAplicacao(BuscaNaoEncontrada));
        }

        if (request.UserName != null && request.UserName != user.Username)
            user.Username = request.UserName;
        if (request.Email != null && request.Email != user.Email)
            user.Email = request.Email;
        if (request.PasswordHash != null)
        {
            if (!_encryptionService.Verify(request.PasswordHash, user.PasswordHash))
                user.PasswordHash = _encryptionService.Encrypt(request.PasswordHash);
        }

        try
        {
            await _userRepository.UpdateUserAsync(user);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
        catch
        {
            return Result.Error<UpdateUserResponse>(new ExcecaoAplicacao(FalhaAoAtualizar));
        }

        return Result.Success(new UpdateUserResponse(user.UserId, user.Username));
    }
}