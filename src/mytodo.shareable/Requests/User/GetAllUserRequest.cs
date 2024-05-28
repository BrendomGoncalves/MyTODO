using MediatR;
using mytodo.shareable.Responses.User;
using OperationResult;

namespace mytodo.shareable.Requests.User;

public class GetAllUserRequest : IRequest<Result<List<GetUserResponse>>> {}