using LogLiteThinking.Application.Common.Response;

namespace LogLiteThinking.Application.Features.Logs.Command.DeleteLog;

public class DeleteLogCommand : IRequest<ResultResponse<bool>>
{
  public Guid Id { get; set; }
}