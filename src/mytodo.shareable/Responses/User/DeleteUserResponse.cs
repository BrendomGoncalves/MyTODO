namespace mytodo.shareable.Responses.User;

public record DeleteUserResponse(
    int UserId,
    string UserName   
);