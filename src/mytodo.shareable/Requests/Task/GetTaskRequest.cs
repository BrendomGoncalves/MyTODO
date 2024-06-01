using MediatR;
using mytodo.shareable.Responses.Task;
using OperationResult;

namespace mytodo.shareable.Requests.Task;

public class GetTaskRequest : IRequest<Result<GetTaskResponse>>
{
    public required int TaskId { get; set; }
}