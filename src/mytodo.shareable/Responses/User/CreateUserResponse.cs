using System.Diagnostics.CodeAnalysis;

namespace mytodo.shareable.Responses.User;

[ExcludeFromCodeCoverage]
public record CreateUserResponse(
    int UserId,
    string UserName
);