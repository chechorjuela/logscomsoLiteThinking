using LogLiteThinking.Application.Common.DTO.Response;
using LogLiteThinking.Application.Common.Response;
using LogLiteThinking.Application.Features.Logs.Command.CreateLog;
using LogLiteThinking.Domain.Entities;
using LogLiteThinking.Domain.Repositories;
using LogLiteThinking.Infrastructure.Utils;

namespace LogLiteThinking.Application.Features.Logs.Command.UpdateLog;

public class UpdateLogCommandHandler : UseCaseHandler, IRequestHandler<UpdateLogCommand, ResultResponse<LogResponseDto>>
{
  private readonly CosmoService _cosmoService;
  private readonly ILogRepository _repository;
  private readonly IMapper _mapper;
  
  public UpdateLogCommandHandler(
    CosmoService cosmoService,
    ILogRepository repository, IMapper mapper)
  {
    _cosmoService = cosmoService;
    _mapper = mapper;
    _repository = repository;
  }

  public async Task<ResultResponse<LogResponseDto>> Handle(UpdateLogCommand request, CancellationToken cancellationToken)
  {
    var entity = _mapper.Map<Log>(request);
    var response = await _repository.UpdateAsync(entity);
    var logItemEntity = _mapper.Map<LogItem>(request);
    await _cosmoService.UpdateLogItemAsync(request.Id.ToString(), logItemEntity);
    var dto = _mapper.Map<LogResponseDto>(response);
    return Succeded(dto);
  }
}