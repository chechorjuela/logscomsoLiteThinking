using LogLiteThinking.Application.Common.DTO.Response;
using LogLiteThinking.Application.Common.Response;
using LogLiteThinking.Infrastructure.Enums;

namespace LogLiteThinking.Application.Features.Logs.Command.UpdateLog;

public class UpdateLogCommand : IRequest<ResultResponse<LogResponseDto>>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Priority Priority { get; set; }
}