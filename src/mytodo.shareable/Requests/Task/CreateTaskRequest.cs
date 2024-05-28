using MediatR;
using mytodo.shareable.Responses.Task;
using OperationResult;

namespace mytodo.shareable.Requests.Task;

public class CreateTaskRequest : IRequest<Result<CreateTaskResponse>>
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public string Status { get; set; } = "Pending";
    public string Priority { get; set; } = "Medium";
    public int UserId { get; set; }
}