using MediatR;
using mytodo.domain.Repository;
using mytodo.shareable.Requests.User;
using mytodo.shareable.Responses.User;
using OperationResult;

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

        return Result.Success(new GetUserResponse(user.UserId, user.Username, user.Email));
    }
}