using MediatR;
using mytodo.domain.Repository;
using mytodo.shareable.Excecoes;
using mytodo.shareable.Requests.Task;
using mytodo.shareable.Responses.Task;
using OperationResult;
using static mytodo.shareable.Enums.Cadastro;

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

        if (task == null)
        {
            return Result.Error<UpdateTaskResponse>(
                new ExcecaoAplicacao(BuscaNaoEncontrada));
        }

        if (request.Title != null && request.Title != task.Title)
            task.Title = request.Title;
        if (request.Description != null && request.Description != task.Description)
            task.Description = request.Description;
        if (request.DataVencimento != task.DataVencimento && request.DataVencimento != new DateOnly(1, 1, 1))
            task.DataVencimento = request.DataVencimento;
        if (request.Status != null && request.Status != task.Status)
            task.Status = request.Status;
        if (request.Priority != null && request.Priority != task.Priority)
            task.Priority = request.Priority;

        task.UpdatedAt = DateTime.Now;

        try
        {
            await _taskRepository.UpdateTaskAsync(task);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
        catch
        {
            return Result.Error<UpdateTaskResponse>(
                new ExcecaoAplicacao(FalhaAoAtualizar));
        }

        return Result.Success(new UpdateTaskResponse(task.TaskId, task.Title));
    }
}