using MediatR;
using mytodo.shareable.Responses.Task;
using OperationResult;

namespace mytodo.shareable.Requests.Task;

public class UpdateTaskRequest : IRequest<Result<UpdateTaskResponse>>
{
    public required int TaskId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateOnly DataVencimento { get; set; }
    public string? Status { get; set; }
    public string? Priority { get; set; }
}