using System.Diagnostics.CodeAnalysis;

namespace mytodo.shareable.Responses.User;

[ExcludeFromCodeCoverage]
public record UpdateUserResponse(
    int UserId,
    string UserName   
);