using LogLiteThinking.Application.Common.DTO.Response;
using LogLiteThinking.Application.Common.Response;
using LogLiteThinking.Application.Features.Logs.Queries.GetLogsAll;
using LogLiteThinking.Domain.Entities;
using LogLiteThinking.Domain.Repositories;

namespace LogLiteThinking.Application.Features.Logs.Queries.GetLogById;

public class GetLogByIdQuery : IRequest<ResultResponse<LogResponseDto>>
{
  public Guid Id { get; set; }
  
  public class GetLogByIdQueryHandler(
    IBaseRepository<Log> repository,
    IMapper _mapper)
    : UseCaseHandler, IRequestHandler<GetLogByIdQuery, ResultResponse<LogResponseDto>>
  {

    public async Task<ResultResponse<LogResponseDto>> Handle(GetLogByIdQuery request, CancellationToken cancellationToken)
    {
      var logs = await repository.GetByIdAsync(request.Id);

      var response = _mapper.Map<LogResponseDto>(logs);
      return Succeded(response);
    }
  }
}