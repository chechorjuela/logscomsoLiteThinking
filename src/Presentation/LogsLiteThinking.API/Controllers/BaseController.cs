using AutoMapper;
using LogLiteThinking.Application.Common.Response;
using LogsLiteThinking.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogsLiteThinking.API.Controllers;

[ApiController]
[Route("/api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[Produces("application/json")]
public abstract class BaseController : ControllerBase
{
  private IMediator? _mediator;

  protected IMediator Mediator => this._mediator ??= EngineContext.Current.Resolve<IMediator>();

  protected IMapper Mapper => EngineContext.Current.Resolve<IMapper>();

  protected ActionResult FromResult<T>(ResultResponse<T> result) => result.StatusCode switch
  {
    ResultType.Created => this.Ok(result),
    ResultType.Ok => this.Ok(result),
    ResultType.Invalid => this.BadRequest(result),
    ResultType.Unexpected => this.BadRequest(result),
    ResultType.PartialOk => this.Ok(result),
    ResultType.NotFound => this.NotFound(result),
    _ => throw new Exception("Unhadled Result...")
  };
}