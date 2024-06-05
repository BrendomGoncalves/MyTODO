using MediatR;
using Microsoft.AspNetCore.Mvc;
using mytodo.api.Controllers;
using mytodo.shareable.Requests.Task;
using mytodo.shareable.Responses.Task;
using NSubstitute;
using Xunit;

namespace mytodo.api.tests.Controllers;

public class TaskControllerTests
{
    [Fact]
    public async Task CreateTaskAsync_WhenCalled_ReturnsTask()
    {
        // Arrange
        var mediator = Substitute.For<IMediator>();
        var controller = new TaskController(mediator);
        var request = new CreateTaskRequest
        {
            Title = "Task Test",
            Description = "Description Test",
            DataVencimento = new DateOnly(2022, 12, 31),
            UserId = 1
        };

        // Act
        var result = await controller.CreateTaskAsync(request);

        // Assert
        var actionResult = Assert.IsType<ActionResult<CreateTaskResponse>>(result);
    }

    [Fact]
    public async Task DeleteTaskAsync_WhenCalled_ReturnsTask()
    {
        // Arrange
        var mediator = Substitute.For<IMediator>();
        var controller = new TaskController(mediator);
        var request = new DeleteTaskRequest
        {
            TaskId = 1
        };

        // Act
        var result = await controller.DeleteTaskAsync(request);

        // Assert
        var actionResult = Assert.IsType<ActionResult<DeleteTaskResponse>>(result);
    }

    [Fact]
    public async Task GetTaskAsync_WhenCalled_ReturnsTask()
    {
        // Arrange
        var mediator = Substitute.For<IMediator>();
        var controller = new TaskController(mediator);
        var expectedResponse = new GetTaskResponse(1, "Task Test", "Description Test", new DateOnly(2022, 12, 31), "Pending", "Medium", 1);

        mediator.Send(Arg.Any<GetTaskRequest>()).ReturnsForAnyArgs(new GetTaskResponse(1, "Task Test", "Description Test", new DateOnly(2022, 12, 31), "Pending", "Medium", 1));

        // Act
        var result = await controller.GetTaskAsync(1);

        // Assert
        var actionResult = Assert.IsType<ActionResult<GetTaskResponse>>(result);
        var okResult = Assert.IsType<ObjectResult>(actionResult.Result);
        var returnValue = Assert.IsType<GetTaskResponse>(okResult.Value);

        Assert.Equal(expectedResponse, returnValue);
    }

    [Fact]
    public async Task GetTasksAsync_WhenCalled_ReturnsTask()
    {
        // Arrange
        var mediator = Substitute.For<IMediator>();
        var controller = new TaskController(mediator);
        var expectedResponse = new List<GetTaskResponse>
        {
            new GetTaskResponse(1, "Task Test", "Description Test", new DateOnly(2022, 12, 31), "Pending", "Medium", 1)
        };

        mediator.Send(Arg.Any<GetAllTaskRequest>()).ReturnsForAnyArgs(new List<GetTaskResponse>
        {
            new GetTaskResponse(1, "Task Test", "Description Test", new DateOnly(2022, 12, 31), "Pending", "Medium", 1)
        });

        // Act
        var result = await controller.GetTasksAsync();

        // Assert
        var actionResult = Assert.IsType<ActionResult<List<GetTaskResponse>>>(result);
        var okResult = Assert.IsType<ObjectResult>(actionResult.Result);
        var returnValue = Assert.IsType<List<GetTaskResponse>>(okResult.Value);

        Assert.Equal(expectedResponse, returnValue);
    }

    [Fact]
    public async Task UpdateTaskAsync_WhenCalled_ReturnsTask()
    {
        // Arrange
        var mediator = Substitute.For<IMediator>();
        var controller = new TaskController(mediator);
        var request = new UpdateTaskRequest
        {
            TaskId = 1,
            Title = "Task Test",
            Description = "Description Test",
            DataVencimento = new DateOnly(2022, 12, 31),
            Status = "Pending",
            Priority = "Medium"
        };

        // Act
        var result = await controller.UpdateTaskAsync(request);

        // Assert
        var actionResult = Assert.IsType<ActionResult<UpdateTaskResponse>>(result);
    }
}