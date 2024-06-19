using System.Diagnostics.CodeAnalysis;
using MediatR;
using mytodo.shareable.Responses.Task;
using OperationResult;

namespace mytodo.shareable.Requests.Task;

[ExcludeFromCodeCoverage]
public class GetTaskRequest : IRequest<Result<GetTaskResponse>>
{
    public required int TaskId { get; set; }
}