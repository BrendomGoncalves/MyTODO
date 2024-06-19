using System.Diagnostics.CodeAnalysis;

namespace mytodo.shareable.Responses.Task;

[ExcludeFromCodeCoverage]
public record UpdateTaskResponse(
    int TaskId,
    string Title  
);