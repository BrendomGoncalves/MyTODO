namespace mytodo.shareable.Responses.User;

public record CreateUserResponse(
    int UserId,
    string UserName
);