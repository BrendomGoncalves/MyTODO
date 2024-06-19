using System.Diagnostics.CodeAnalysis;

namespace mytodo.shareable.Responses.Task;

[ExcludeFromCodeCoverage]
public record CreateTaskResponse(
    int TaskId,
    string Title
);