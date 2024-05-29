using MediatR;
using Microsoft.AspNetCore.Mvc;
using mytodo.shareable.Excecoes;
using mytodo.shareable.Requests.User;
using mytodo.shareable.Responses.User;

namespace mytodo.api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : BaseController
{
    public UserController(IMediator mediator) : base(mediator) {}
    
    [HttpPost]
    [ProducesResponseType(typeof(CreateUserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateUserResponse>> CreateUserAsync([FromBody] CreateUserRequest request) =>
        await SendCommand(request);
    
    [HttpDelete]
    [ProducesResponseType(typeof(DeleteUserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DeleteUserResponse>> DeleteUserAsync([FromBody] DeleteUserRequest request) =>
        await SendCommand(request);

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetUserResponse>> GetUserAsync(int id)
    {
        var request = new GetUserRequest { UserId = id };
        return await SendCommand(request);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<GetUserResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<GetUserResponse>>> GetUsersAsync()
    {
        var request = new GetAllUserRequest();
        return await SendCommand(request);
    }
    
    [HttpPut]
    [ProducesResponseType(typeof(UpdateUserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UpdateUserResponse>> UpdateUserAsync([FromBody] UpdateUserRequest request) =>
        await SendCommand(request);
}