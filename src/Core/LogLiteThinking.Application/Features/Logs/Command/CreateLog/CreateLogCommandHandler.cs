using LogLiteThinking.Application.Common.DTO.Response;
using LogLiteThinking.Application.Common.Response;
using LogLiteThinking.Domain.Entities;
using LogLiteThinking.Domain.Repositories;
using LogLiteThinking.Infrastructure.Utils;

namespace LogLiteThinking.Application.Features.Logs.Command.CreateLog;

public class CreateLogCommandHandler : UseCaseHandler, IRequestHandler<CreateLogCommand, ResultResponse<LogResponseDto>>
{
  private readonly CosmoService _cosmoService;
  private readonly IUnitOfWork<Log> _unitOfWork;
  private readonly IMapper _mapper;

  public CreateLogCommandHandler(CosmoService cosmoService, IUnitOfWork<Log> unitOfWork, IMapper mapper)
  {
    _cosmoService = cosmoService;
    _unitOfWork = unitOfWork;
    _mapper = mapper;
  }

  public async Task<ResultResponse<LogResponseDto>> Handle(CreateLogCommand request, CancellationToken cancellationToken)
  {
    
    Log log = _mapper.Map<Log>(request);
    log.CreatedAt = DateTime.Now;
    var entity = await _unitOfWork.Repository.AddAsync(log);
    LogItem logItem = new LogItem()
    {
      id = Guid.NewGuid(),
      Title = entity.Title,
      Description = entity.Description,
      Priority = entity.Priority,
      CreatedAt = entity.CreatedAt
    };
    await _cosmoService.AddLogAsync(logItem);
    var response = _mapper.Map<LogResponseDto>(entity);
    return Created(response);
  }
}