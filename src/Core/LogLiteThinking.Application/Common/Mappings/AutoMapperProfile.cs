using LogLiteThinking.Application.Common.DTO.Response;
using LogLiteThinking.Application.Features.Logs.Command.CreateLog;
using LogLiteThinking.Application.Features.Logs.Command.UpdateLog;
using LogLiteThinking.Domain.Entities;
using LogLiteThinking.Infrastructure.Utils;

namespace LogsLiteThinking.API.Common.Mappings;

public class AutoMapperProfile : Profile
{
  public AutoMapperProfile()
  {
    this.CreateMap<Log, LogResponseDto>();
    this.CreateMap<LogItem, LogResponseDto>()
      .ForMember( dest => dest.Id, opt => opt.MapFrom( src => src.id));

    this.CreateMap<CreateLogCommand, Log>();
    this.CreateMap<UpdateLogCommand, Log>();

  }
}