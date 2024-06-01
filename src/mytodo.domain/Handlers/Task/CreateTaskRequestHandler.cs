using MediatR;
using mytodo.domain.Entities;
using mytodo.domain.Repository;
using mytodo.shareable.Excecoes;
using mytodo.shareable.Requests.Task;
using mytodo.shareable.Responses.Task;
using OperationResult;
using static mytodo.shareable.Enums.Cadastro;

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
            Description = request.Description ?? "Sem descrição",
            DataVencimento = request.DataVencimento ?? new DateOnly(1, 1, 1),
            Status = request.Status,
            Priority = request.Priority,
            UserId = request.UserId
        };

        try
        {
            await _taskRepository.CreateTaskAsync(task);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
        catch
        {
            return Result.Error<CreateTaskResponse>(
                new ExcecaoAplicacao(FalhaAoCriar));
        }

        return Result.Success(new CreateTaskResponse(task.TaskId, task.Title));
    }
}