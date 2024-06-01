using MediatR;
using mytodo.shareable.Responses.Task;
using OperationResult;

namespace mytodo.shareable.Requests.Task;

public class DeleteTaskRequest : IRequest<Result<DeleteTaskResponse>>
{
    public required int TaskId { get; set; }
}