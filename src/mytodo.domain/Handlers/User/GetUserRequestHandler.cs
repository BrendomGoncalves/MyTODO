using MediatR;
using mytodo.domain.Repository;
using mytodo.shareable.Excecoes;
using mytodo.shareable.Requests.User;
using mytodo.shareable.Responses.User;
using OperationResult;
using static mytodo.shareable.Enums.Cadastro;

namespace mytodo.domain.Handlers.User;

public class GetUserRequestHandler : IRequestHandler<GetUserRequest, Result<GetUserResponse>>
{
    private readonly IUserRepository _userRepository;
    
    public GetUserRequestHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<Result<GetUserResponse>> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.UserId);

        if (user == null)
        {
            return Result.Error<GetUserResponse>(new ExcecaoAplicacao(BuscaNaoEncontrada));
        }

        return Result.Success(new GetUserResponse(user.UserId, user.Username, user.Email));
    }
}