using System.Diagnostics.CodeAnalysis;

namespace mytodo.shareable.Responses.Task;

[ExcludeFromCodeCoverage]
public record DeleteTaskResponse(
    int TaskId,
    string Title
);