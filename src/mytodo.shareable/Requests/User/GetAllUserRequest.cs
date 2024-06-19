using System.Diagnostics.CodeAnalysis;
using MediatR;
using mytodo.shareable.Responses.User;
using OperationResult;

namespace mytodo.shareable.Requests.User;

[ExcludeFromCodeCoverage]
public class GetAllUserRequest : IRequest<Result<List<GetUserResponse>>> {}