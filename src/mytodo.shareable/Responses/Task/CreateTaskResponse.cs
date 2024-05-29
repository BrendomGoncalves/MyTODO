namespace mytodo.shareable.Responses.Task;

public record CreateTaskResponse(
    int TaskId,
    string Title
);