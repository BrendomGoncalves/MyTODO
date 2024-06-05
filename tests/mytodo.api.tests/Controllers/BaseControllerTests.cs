using MediatR;
using Microsoft.AspNetCore.Mvc;
using mytodo.shareable.Excecoes;
using NSubstitute;
using OperationResult;
using Xunit;

namespace mytodo.api.tests.Controllers;

public class BaseControllerTests
{
    [Fact]
    public void SendCommand_WithRequest_ReturnsStatusCode()
    {
        // Arrange
        var mediator = Substitute.For<IMediator>();
        var request = Substitute.For<IRequest<Result>>();
        var controller = new BaseControllerTestable(mediator);

        // Act
        var result = controller.SendCommand(request);

        // Assert
        Assert.IsType<Task<ActionResult>>(result);
    }
    
    [Fact]
    public void SendCommand_WithRequestAndStatusCode_ReturnsStatusCode()
    {
        // Arrange
        var mediator = Substitute.For<IMediator>();
        var request = Substitute.For<IRequest<Result>>();
        var controller = new BaseControllerTestable(mediator);

        // Act
        var result = controller.SendCommand(request, 201);

        // Assert
        Assert.IsType<Task<ActionResult>>(result);
    }
    
    [Fact]
    public void SendCommand_WithRequestAndT_ReturnsStatusCode()
    {
        // Arrange
        var mediator = Substitute.For<IMediator>();
        var request = Substitute.For<IRequest<Result<string>>>();
        var controller = new BaseControllerTestable(mediator);

        // Act
        var result = controller.SendCommand(request);

        // Assert
        Assert.IsType<Task<ActionResult<string>>>(result);
    }
    
    [Fact]
    public void SendCommand_WithRequestAndTAndStatusCode_ReturnsStatusCode()
    {
        // Arrange
        var mediator = Substitute.For<IMediator>();
        var request = Substitute.For<IRequest<Result<string>>>();
        var controller = new BaseControllerTestable(mediator);

        // Act
        var result = controller.SendCommand(request, 201);

        // Assert
        Assert.IsType<Task<ActionResult<string>>>(result);
    }
    
    [Fact]
    public void HandleError_WithSemResultadosExcecao_ReturnsNoContent()
    {
        // Arrange
        var mediator = Substitute.For<IMediator>();
        var controller = new BaseControllerTestable(mediator);

        // Act
        var result = controller.HandleError(new SemResultadosExcecao());

        // Assert
        Assert.IsType<NoContentResult>(result);
    }
    
    [Fact]
    public void HandleError_WithExcecaoAplicacao_ReturnsBadRequest()
    {
        // Arrange
        var mediator = Substitute.For<IMediator>();
        var controller = new BaseControllerTestable(mediator);

        // Act
        var result = controller.HandleError(new ExcecaoAplicacao(new ResultadoErro()));

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }
    
    [Fact]
    public void HandleError_WithDefault_ReturnsBadRequest()
    {
        // Arrange
        var mediator = Substitute.For<IMediator>();
        var controller = new BaseControllerTestable(mediator);

        // Act
        var result = controller.HandleError(new Exception());

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }
    
    [Fact]
    public void FormatErrorMessage_WithErrors_ReturnsResult()
    {
        // Arrange
        var mediator = Substitute.For<IMediator>();
        var controller = new BaseControllerTestable(mediator);
        var responseErro = new ResultadoErro();

        // Act
        var result = controller.FormatErrorMessage(responseErro, new List<string> { "error" });

        // Assert
        Assert.Equal(" : error", result.Descricao);
    }
    
    [Fact]
    public void FormatErrorMessage_WithoutErrors_ReturnsResult()
    {
        // Arrange
        var mediator = Substitute.For<IMediator>();
        var controller = new BaseControllerTestable(mediator);
        var responseErro = new ResultadoErro();

        // Act
        var result = controller.FormatErrorMessage(responseErro);

        // Assert
        Assert.Equal(responseErro, result);
    }
}