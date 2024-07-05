using LogLiteThinking.Application.Common.Response;
using LogLiteThinking.Domain.Repositories;
using LogLiteThinking.Infrastructure.Utils;

namespace LogLiteThinking.Application.Features.Logs.Command.DeleteLog;

public class DeleteLogCommandHandler : UseCaseHandler, IRequestHandler<DeleteLogCommand, ResultResponse<bool>>
{
  private readonly ILogRepository _repository;
  private readonly CosmoService _cosmoService;
  
  public DeleteLogCommandHandler(
    CosmoService cosmoService,
     ILogRepository repository
    )
  {
    _cosmoService = cosmoService;
    _repository = repository;
  }

  public async Task<ResultResponse<bool>> Handle(DeleteLogCommand request, CancellationToken cancellationToken)
  {
    var success = await _repository.DeleteAsync(request.Id);
    await _cosmoService.DeleteLogItemAsync(request.Id.ToString());

    return Succeded(success);

  }
}