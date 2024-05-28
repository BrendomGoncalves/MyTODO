using MediatR;
using mytodo.shareable.Responses.User;
using OperationResult;

namespace mytodo.shareable.Requests.User;

public class GetUserRequest : IRequest<Result<GetUserResponse>>
{
    public int UserId { get; set; }
}