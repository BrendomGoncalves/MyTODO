using MediatR;
using mytodo.shareable.Responses.Task;
using OperationResult;

namespace mytodo.shareable.Requests.Task;

public class UpdateTaskRequest : IRequest<Result<UpdateTaskResponse>>
{
    public int TaskId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public string? Status { get; set; }
    public string? Priority { get; set; }
}