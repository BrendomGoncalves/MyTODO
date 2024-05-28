using MediatR;
using mytodo.shareable.Responses.Task;
using OperationResult;

namespace mytodo.shareable.Requests.Task;

public class GetAllTaskRequest : IRequest<Result<List<GetTaskResponse>>> {}