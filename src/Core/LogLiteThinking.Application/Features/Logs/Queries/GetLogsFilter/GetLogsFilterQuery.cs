using LogLiteThinking.Application.Common.DTO.Response;
using LogLiteThinking.Application.Common.Response;
using LogLiteThinking.Infrastructure.Enums;

namespace LogLiteThinking.Application.Features.Logs.Queries.GetLogsFilter;

public class GetLogsFilterQuery : IRequest<ResultResponse<List<LogResponseDto>>>
{
  public int Priority;
}