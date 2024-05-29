namespace mytodo.shareable.Responses.Task;

public record DeleteTaskResponse(
    int TaskId,
    string Title
);