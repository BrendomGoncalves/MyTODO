using MediatR;
using mytodo.domain.Repository;
using mytodo.shareable.Requests.Task;
using mytodo.shareable.Responses.Task;
using OperationResult;

namespace mytodo.domain.Handlers.Task;

public class UpdateTaskRequestHandler : IRequestHandler<UpdateTaskRequest, Result<UpdateTaskResponse>>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public UpdateTaskRequestHandler(ITaskRepository taskRepository, IUnitOfWork unitOfWork)
    {
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result<UpdateTaskResponse>> Handle(UpdateTaskRequest request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetTaskByIdAsync(request.TaskId);

        if(request.Title != null) task.Title = request.Title;
        if(request.Description != null) task.Description = request.Description;
        task.DueDate = request.DueDate;
        if(request.Status != null) task.Status = request.Status;
        if(request.Priority != null) task.Priority = request.Priority;

        await _taskRepository.UpdateTaskAsync(task);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(new UpdateTaskResponse(task.TaskId, task.Title));
    }
}