using System.Diagnostics.CodeAnalysis;
using MediatR;
using mytodo.shareable.Responses.User;
using OperationResult;

namespace mytodo.shareable.Requests.User;

[ExcludeFromCodeCoverage]
public class UpdateUserRequest : IRequest<Result<UpdateUserResponse>>
{
    public required int UserId { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
}