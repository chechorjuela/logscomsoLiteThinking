using AutoMapper;
using LogLiteThinking.Application.Common.DTO.Response;
using LogLiteThinking.Application.Common.Response;
using LogLiteThinking.Domain.Entities;
using LogLiteThinking.Domain.Repositories;
using LogLiteThinking.Infrastructure.Utils;

namespace LogLiteThinking.Application.Features.Logs.Queries.GetLogsAll;

public class GetLogsAllQuery : IRequest<ResultResponse<List<LogResponseDto>>>
{
  public class GetLogsAllQueryHandler(
    CosmoService serviceCosmo,
    ILogRepository repository,
    IMapper _mapper)
    : UseCaseHandler, IRequestHandler<GetLogsAllQuery, ResultResponse<List<LogResponseDto>>>
  {

    public async Task<ResultResponse<List<LogResponseDto>>> Handle(GetLogsAllQuery request, CancellationToken cancellationToken)
    {
      //var logs = await repository.GetAllAsync();
      var logs = await serviceCosmo.GetLogItemsAsync();
      var response = _mapper.Map<List<LogResponseDto>>(logs);
      return Succeded(response);
    }
  }
}