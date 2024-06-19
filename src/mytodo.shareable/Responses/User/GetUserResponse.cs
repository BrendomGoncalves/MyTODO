using System.Diagnostics.CodeAnalysis;

namespace mytodo.shareable.Responses.User;

[ExcludeFromCodeCoverage]
public record GetUserResponse(
    int UserId,
    string UserName,
    string Email
);