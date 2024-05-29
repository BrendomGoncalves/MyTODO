namespace mytodo.shareable.Responses.Task;

public record UpdateTaskResponse(
    int TaskId,
    string Title  
);