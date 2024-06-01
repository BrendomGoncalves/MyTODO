using MediatR;
using mytodo.domain.Repository;
using mytodo.shareable.Excecoes;
using mytodo.shareable.Requests.Task;
using mytodo.shareable.Responses.Task;
using OperationResult;
using static mytodo.shareable.Enums.Cadastro;

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

        if (task == null)
        {
            return Result.Error<GetTaskResponse>(
                new ExcecaoAplicacao(BuscaNaoEncontrada));
        }

        return Result.Success(new GetTaskResponse(task.TaskId, task.Title, task.Description, task.DataVencimento, task.Status,
            task.Priority, task.UserId));
    }
}