using MediatR;
using mytodo.shareable.Responses.Task;
using OperationResult;

namespace mytodo.shareable.Requests.Task;

public class CreateTaskRequest : IRequest<Result<CreateTaskResponse>>
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    public DateOnly? DataVencimento { get; set; }
    public string Status { get; set; } = "Pending";
    public string Priority { get; set; } = "Medium";
    public required int UserId { get; set; }
}