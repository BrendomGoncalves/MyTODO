using MediatR;
using Microsoft.AspNetCore.Mvc;
using mytodo.shareable.Excecoes;
using mytodo.shareable.Requests.Task;
using mytodo.shareable.Responses.Task;

namespace mytodo.api.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : BaseController
{
    public TaskController(IMediator mediator) : base(mediator) {}

    [HttpPost]
    [ProducesResponseType(typeof(CreateTaskResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateTaskResponse>> CreateTaskAsync([FromBody] CreateTaskRequest request) =>
        await SendCommand(request);
    
    [HttpDelete]
    [ProducesResponseType(typeof(DeleteTaskResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DeleteTaskResponse>> DeleteTaskAsync([FromBody] DeleteTaskRequest request) =>
        await SendCommand(request);

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(GetTaskResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetTaskResponse>> GetTaskAsync(int id)
    {
        var request = new GetTaskRequest{TaskId = id};
        return await SendCommand(request);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<GetTaskResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<GetTaskResponse>>> GetTasksAsync()
    {
        var request = new GetAllTaskRequest();
        return await SendCommand(request);
    }
    
    [HttpPut]
    [ProducesResponseType(typeof(UpdateTaskResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UpdateTaskResponse>> UpdateTaskAsync([FromBody] UpdateTaskRequest request) =>
        await SendCommand(request);
}