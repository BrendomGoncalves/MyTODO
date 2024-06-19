using System.Diagnostics.CodeAnalysis;
using MediatR;
using mytodo.shareable.Responses.User;
using OperationResult;

namespace mytodo.shareable.Requests.User;

[ExcludeFromCodeCoverage]
public class GetUserRequest : IRequest<Result<GetUserResponse>>
{
    public required int UserId { get; set; }
}