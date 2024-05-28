using mytodo.domain.Entities;

namespace mytodo.shareable.Responses.User;

public record DeleteUserResponse(
    int UserId,
    string UserName,
    string Email,
    IEnumerable<TaskEntity>? Tasks    
);