using LogLiteThinking.Application.Common.DTO.Response;
using LogLiteThinking.Application.Common.Response;
using LogLiteThinking.Domain.Entities;
using LogLiteThinking.Domain.Repositories;
using LogLiteThinking.Infrastructure.Utils;

namespace LogLiteThinking.Application.Features.Logs.Queries.GetLogsFilter;

public class GetLogsFilterQueryHandler : UseCaseHandler, IRequestHandler<GetLogsFilterQuery, ResultResponse<List<LogResponseDto>>>
{
  private readonly ILogRepository _repository;
  private readonly IMapper _mapper;
  private readonly CosmoService _cosmoService;
  
  public GetLogsFilterQueryHandler(
    CosmoService cosmoService,
    ILogRepository repository, IMapper mapper)
  {
    _mapper = mapper;
    _repository = repository;
    _cosmoService = cosmoService;
  }

  public async Task<ResultResponse<List<LogResponseDto>>> Handle(GetLogsFilterQuery request, CancellationToken cancellationToken)
  {
    
    var entity = await _repository.FilterByPrority(request.Priority);
    var entityFilter = await _cosmoService.GetLogItemsByFilterAsync(request.Priority);
    var response = _mapper.Map<List<LogResponseDto>>(entityFilter);
    return Succeded(response);
  }
}