namespace mytodo.shareable.Responses.Task;

public record UpdateTaskResponse(
    int TaskId,
    string Title,
    string Description,
    DateTime DueDate,
    string Status,
    string Priority,
    int UserId    
);