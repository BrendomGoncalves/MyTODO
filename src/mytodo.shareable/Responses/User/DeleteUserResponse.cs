using System.Diagnostics.CodeAnalysis;

namespace mytodo.shareable.Responses.User;

[ExcludeFromCodeCoverage]
public record DeleteUserResponse(
    int UserId,
    string UserName   
);