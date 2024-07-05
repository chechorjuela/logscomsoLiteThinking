using LogLiteThinking.Infrastructure.Enums;

namespace LogLiteThinking.Application.Common.DTO.Response;

public class LogResponseDto
{
  public Guid Id { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }
  public int Priority { get; set; }
  public DateTime CreatedAt { get; set; }
}