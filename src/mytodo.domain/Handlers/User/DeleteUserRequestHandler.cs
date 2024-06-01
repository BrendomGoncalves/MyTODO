using MediatR;
using mytodo.domain.Repository;
using mytodo.shareable.Excecoes;
using mytodo.shareable.Requests.User;
using mytodo.shareable.Responses.User;
using OperationResult;
using static mytodo.shareable.Enums.Cadastro;

namespace mytodo.domain.Handlers.User;

public class DeleteUserRequestHandler : IRequestHandler<DeleteUserRequest, Result<DeleteUserResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserRequestHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<DeleteUserResponse>> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.UserId);

        if (user == null)
        {
            return Result.Error<DeleteUserResponse>(new ExcecaoAplicacao(BuscaNaoEncontrada));
        }

        user.DeletedAt = DateTime.Now;
        
        try
        {
            await _userRepository.DeleteUserAsync(user);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
        catch
        {
            return Result.Error<DeleteUserResponse>(new ExcecaoAplicacao(FalhaAoDeletar));
        }

        return Result.Success(new DeleteUserResponse(user.UserId, user.Username));
    }
}