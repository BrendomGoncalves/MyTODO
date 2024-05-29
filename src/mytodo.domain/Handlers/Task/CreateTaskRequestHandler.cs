using MediatR;
using mytodo.domain.Entities;
using mytodo.domain.Repository;
using mytodo.shareable.Requests.Task;
using mytodo.shareable.Responses.Task;
using OperationResult;

namespace mytodo.domain.Handlers.Task;

public class CreateTaskRequestHandler : IRequestHandler<CreateTaskRequest, Result<CreateTaskResponse>>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTaskRequestHandler(ITaskRepository taskRepository, IUnitOfWork unitOfWork)
    {
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<CreateTaskResponse>> Handle(CreateTaskRequest request, CancellationToken cancellationToken)
    {
        var task = new TaskEntity
        {
            Title = request.Title,
            Description = request.Description,
            DueDate = request.DueDate,
            Status = request.Status,
            Priority = request.Priority,
            UserId = request.UserId
        };

        await _taskRepository.CreateTaskAsync(task);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(new CreateTaskResponse(task.TaskId, task.Title));
    }
}