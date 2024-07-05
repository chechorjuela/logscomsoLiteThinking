using LogLiteThinking.Application.Common.DTO.Response;
using LogLiteThinking.Application.Common.Response;
using LogLiteThinking.Domain.Enums;

namespace LogLiteThinking.Application.Features.Logs.Command.CreateLog;

public class CreateLogCommand : IRequest<ResultResponse<LogResponseDto>>
{
  public string Title { get; set; }
  public string Description { get; set; }
  public int Priority { get; set; }
}