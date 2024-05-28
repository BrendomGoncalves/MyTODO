namespace mytodo.shareable.Responses.Task;

public record DeleteTaskResponse(
    int TaskId,
    string Title,
    string Description,
    DateTime DueDate,
    string Status,
    string Priority,
    int UserId
);