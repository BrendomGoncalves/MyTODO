using System.Diagnostics.CodeAnalysis;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using mytodo.api.Controllers;
using mytodo.shareable.Excecoes;
using OperationResult;

namespace mytodo.api.tests.Controllers;

[ExcludeFromCodeCoverage]
public class BaseControllerTestable : BaseController
{
    public BaseControllerTestable(IMediator mediator) : base(mediator) {}

    public new async Task<ActionResult> SendCommand(IRequest<Result> request, int statusCode = 200)
    {
        return await base.SendCommand(request, statusCode);
    }

    public new async Task<ActionResult<T>> SendCommand<T>(IRequest<Result<T>> request, int statusCode = 200)
    {
        return await base.SendCommand(request, statusCode);
    }
    
    public new ActionResult HandleError(Exception? error)
    {
        return base.HandleError(error);
    }
    
    public new ResultadoErro FormatErrorMessage(ResultadoErro responseErro, IEnumerable<string>? errors = null)
    {
        return base.FormatErrorMessage(responseErro, errors);
    }
}