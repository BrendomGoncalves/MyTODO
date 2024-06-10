using MediatR;
using Microsoft.AspNetCore.Mvc;
using mytodo.api.Controllers;
using mytodo.domain.Services;
using mytodo.shareable.Requests.User;
using mytodo.shareable.Responses.User;
using NSubstitute;
using Xunit;

namespace mytodo.api.tests.Controllers;

public class UserControllerTests
{
    [Fact]
    public async Task CreateUserAsync_WhenCalled_ReturnsUser()
    {
        // Arrange
        var mediator = Substitute.For<IMediator>();
        var controller = new UserController(mediator);
        var encryptService = Substitute.For<IEncryptionService>();
        var request = new CreateUserRequest
        {
            UserName = "UserTest",
            Email = "usertest@email.com",
            PasswordHash = encryptService.Encrypt("userTestPassword")
        };
        var response = new CreateUserResponse(1, "UserTest");
        mediator.Send(Arg.Any<CreateUserRequest>()).Returns(response);

        // Act
        var result = await controller.CreateUserAsync(request);

        // Assert
        var actionResult = Assert.IsType<ActionResult<CreateUserResponse>>(result);
        var okResult = Assert.IsType<ObjectResult>(actionResult.Result);
        var retunValue = Assert.IsType<CreateUserResponse>(okResult.Value);

        Assert.Equal(1, retunValue.UserId);
    }

    [Fact]
    public async Task DeleteUserAsync_WhenCalled_ReturnsUser()
    {
        // Arrange
        var mediator = Substitute.For<IMediator>();
        var controller = new UserController(mediator);
        var request = new DeleteUserRequest { UserId = 1 };
        var response = new DeleteUserResponse(UserId: 1, UserName: "UserTest");
        mediator.Send(Arg.Any<DeleteUserRequest>()).Returns(response);

        // Act
        var result = await controller.DeleteUserAsync(request);

        // Assert
        var actionResult = Assert.IsType<ActionResult<DeleteUserResponse>>(result);
        var okResult = Assert.IsType<ObjectResult>(actionResult.Result);
        var retunValue = Assert.IsType<DeleteUserResponse>(okResult.Value);

        Assert.Equal(1, retunValue.UserId);
    }

    [Fact]
    public async Task GetTaskAsync_WhenCalled_ReturnsUser()
    {
        // Arrange
        var mediator = Substitute.For<IMediator>();
        var controller = new UserController(mediator);
        var response = new GetUserResponse(UserId: 1, UserName: "UserTest", Email: "test@email.com");
        mediator.Send(Arg.Any<GetUserRequest>()).Returns(response);

        // Act
        var result = await controller.GetUserAsync(1);

        // Assert
        var actionResult = Assert.IsType<ActionResult<GetUserResponse>>(result);
        var okResult = Assert.IsType<ObjectResult>(actionResult.Result);
        var retunValue = Assert.IsType<GetUserResponse>(okResult.Value);

        Assert.Equal(1, retunValue.UserId);
    }

    [Fact]
    public async Task GetTasksAsync_WhenCalled_ReturnsUsers()
    {
        // Arrange
        var mediator = Substitute.For<IMediator>();
        var controller = new UserController(mediator);
        var expectedResponse = new List<GetUserResponse>
        {
            new GetUserResponse(UserId: 1, UserName: "UserTest", Email: "test@email.com")
        };

        mediator.Send(Arg.Any<GetAllUserRequest>()).ReturnsForAnyArgs(new List<GetUserResponse>
        {
            new GetUserResponse(UserId: 1, UserName: "UserTest", Email: "test@email.com")
        });

        // Act
        var result = await controller.GetUsersAsync();

        // Assert
        var actionResult = Assert.IsType<ActionResult<List<GetUserResponse>>>(result);
        var okResult = Assert.IsType<ObjectResult>(actionResult.Result);
        var returnValue = Assert.IsType<List<GetUserResponse>>(okResult.Value);

        Assert.Equal(expectedResponse, returnValue);
    }

    [Fact]
    public async Task UpdateUserAsync_WhenCalled_ReturnsUser()
    {
        // Arrange
        var mediator = Substitute.For<IMediator>();
        var encryptService = Substitute.For<IEncryptionService>();
        var controller = new UserController(mediator);
        var request = new UpdateUserRequest
        {
            UserId = 1,
            UserName = "UserTest",
            Email = "test@email.com",
            PasswordHash = encryptService.Encrypt("userTestPassword")
        };
        
        mediator.Send(Arg.Any<UpdateUserRequest>()).Returns(new UpdateUserResponse(UserId: 1, UserName: "UserTest"));

        // Act
        var result = await controller.UpdateUserAsync(request);

        // Assert
        var actionResult = Assert.IsType<ActionResult<UpdateUserResponse>>(result);
        var okResult = Assert.IsType<ObjectResult>(actionResult.Result);
        var returnValue = Assert.IsType<UpdateUserResponse>(okResult.Value);
    }
}