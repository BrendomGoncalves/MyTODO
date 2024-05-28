using mytodo.shareable.Dtos;

namespace mytodo.shareable.Responses.User;

public record CreateUserResponse(
    int UserId,
    string UserName,
    string Email,
    IEnumerable<TaskDto>? Tasks
);