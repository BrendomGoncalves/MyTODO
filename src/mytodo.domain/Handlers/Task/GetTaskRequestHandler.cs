using MediatR;
using mytodo.domain.Repository;
using mytodo.shareable.Requests.Task;
using mytodo.shareable.Responses.Task;
using OperationResult;

namespace mytodo.domain.Handlers.Task;

public class GetTaskRequestHandler : IRequestHandler<GetTaskRequest, Result<GetTaskResponse>>
{
    private readonly ITaskRepository _taskRepository;
    
    public GetTaskRequestHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    public async Task<Result<GetTaskResponse>> Handle(GetTaskRequest request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetTaskByIdAsync(request.TaskId);
        
        return Result.Success(new GetTaskResponse(task.TaskId, task.Title, task.Description, task.DueDate, task.Status, task.Priority, task.UserId));
    }
}