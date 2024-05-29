using MediatR;
using mytodo.domain.Repository;
using mytodo.shareable.Requests.User;
using mytodo.shareable.Responses.User;
using OperationResult;

namespace mytodo.domain.Handlers.User;

public class GetAllUserRequestHandler : IRequestHandler<GetAllUserRequest, Result<List<GetUserResponse>>>
{
    private readonly IUserRepository _userRepository;
    
    public GetAllUserRequestHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<Result<List<GetUserResponse>>> Handle(GetAllUserRequest request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetUsersAsync();
        return Result.Success(
            users.Select(user => new GetUserResponse(user.UserId, user.Username, user.Email)).ToList()
        );
    }
}