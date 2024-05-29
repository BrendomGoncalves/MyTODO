using MediatR;
using mytodo.domain.Repository;
using mytodo.shareable.Requests.Task;
using mytodo.shareable.Responses.Task;
using OperationResult;

namespace mytodo.domain.Handlers.Task;

public class DeleteTaskRequestHandler : IRequestHandler<DeleteTaskRequest, Result<DeleteTaskResponse>>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public DeleteTaskRequestHandler(ITaskRepository taskRepository, IUnitOfWork unitOfWork)
    {
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result<DeleteTaskResponse>> Handle(DeleteTaskRequest request, CancellationToken cancellationToken)
    {
        var taskEncontrada = await _taskRepository.GetTaskByIdAsync(request.TaskId);

        await _taskRepository.DeleteTaskAsync(taskEncontrada);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(new DeleteTaskResponse(taskEncontrada.TaskId, taskEncontrada.Title));
    }
}