using MediatR;
using mytodo.shareable.Responses.Task;
using OperationResult;

namespace mytodo.shareable.Requests.Task;

public class GetTaskRequest : IRequest<Result<GetTaskResponse>>
{
    public int TaskId { get; set; }
}