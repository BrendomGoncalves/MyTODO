namespace mytodo.shareable.Responses.Task;

public record GetTaskResponse(
    int TaskId,
    string Title,
    string? Description,
    DateOnly DataVencimento,
    string Status,
    string Priority,
    int UserId
);