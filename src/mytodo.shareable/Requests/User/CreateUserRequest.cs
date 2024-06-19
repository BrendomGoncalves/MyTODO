using System.Diagnostics.CodeAnalysis;
using MediatR;
using mytodo.shareable.Responses.User;
using OperationResult;

namespace mytodo.shareable.Requests.User;

[ExcludeFromCodeCoverage]
public class CreateUserRequest : IRequest<Result<CreateUserResponse>>
{
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
}