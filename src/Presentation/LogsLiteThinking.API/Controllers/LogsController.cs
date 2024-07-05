using LogLiteThinking.Application.Common.DTO.Response;
using LogLiteThinking.Application.Common.Response;
using LogLiteThinking.Application.Features.Logs.Command.CreateLog;
using LogLiteThinking.Application.Features.Logs.Command.DeleteLog;
using LogLiteThinking.Application.Features.Logs.Command.UpdateLog;
using LogLiteThinking.Application.Features.Logs.Queries.GetLogById;
using LogLiteThinking.Application.Features.Logs.Queries.GetLogsAll;
using LogLiteThinking.Application.Features.Logs.Queries.GetLogsFilter;
using Microsoft.AspNetCore.Mvc;

namespace LogsLiteThinking.API.Controllers;


public class LogsController : BaseController
{
  [HttpGet("")]
  [Produces(typeof(ResultResponse<List<LogResponseDto>>))]
  [ActionName(nameof(GetAll))]
  public async Task<IActionResult> GetAll()
  {
    var query = new GetLogsAllQuery();
    var response = await this.Mediator.Send(query);
    return FromResult(response);
  }
  
  [HttpGet("{id}")]
  [Produces(typeof(ResultResponse<List<LogResponseDto>>))]
  public async Task<IActionResult> GetById([FromRoute] Guid id)
  {
    var query = new GetLogByIdQuery()
    {
      Id = id
    };
    var response = await Mediator.Send(query);
    return FromResult(response);
  }

  [HttpGet("priority/{id}")]
  [Produces(typeof(ResultResponse<List<LogResponseDto>>))]
  public async Task<IActionResult> GetByPriorityId([FromRoute] int id)
  {
    var query = new GetLogsFilterQuery()
    {
      Priority = id
    };
    var response = await this.Mediator.Send(query);
    return FromResult(response);
  }
  
  [HttpPost]
  [Produces(typeof(ResultResponse<LogResponseDto>))]
  [ActionName(nameof(Create))]
  public async Task<IActionResult> Create(CreateLogCommand command)
  {
    var response = await this.Mediator.Send(command);
    return FromResult(response);
  }
  
  [HttpPut("{id}")]
  [Produces(typeof(ResultResponse<LogResponseDto>))]
  [ActionName(nameof(Update))]
  public async Task<IActionResult> Update([FromRoute] Guid id, UpdateLogCommand command)
  {
    command.Id = id;
    var response = await this.Mediator.Send(command);
    return FromResult(response);
  }
  
  [HttpDelete("{id}")]
  [Produces(typeof(ResultResponse<bool>))]
  [ActionName(nameof(Delete))]
  public async Task<IActionResult> Delete([FromRoute] Guid id)
  {
    DeleteLogCommand command = new DeleteLogCommand()
    {
      Id = id
    };
    var response = await this.Mediator.Send(command);
    return FromResult(response);
  }
}