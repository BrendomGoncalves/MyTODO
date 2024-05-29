using MediatR;
using mytodo.domain.Repository;
using mytodo.shareable.Requests.Task;
using mytodo.shareable.Responses.Task;
using OperationResult;

namespace mytodo.domain.Handlers.Task;

public class GetAllTaskRequestHandler : IRequestHandler<GetAllTaskRequest, Result<List<GetTaskResponse>>>
{
    private readonly ITaskRepository _taskRepository;
    
    public GetAllTaskRequestHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    
    public async Task<Result<List<GetTaskResponse>>> Handle(GetAllTaskRequest request, CancellationToken cancellationToken)
    {
        var tasks = await _taskRepository.GetTasksAsync();

        return Result.Success(tasks.Select(task => new GetTaskResponse(task.TaskId, task.Title, task.Description,
            task.DueDate, task.Status, task.Priority, task.UserId)).ToList());
    }
}