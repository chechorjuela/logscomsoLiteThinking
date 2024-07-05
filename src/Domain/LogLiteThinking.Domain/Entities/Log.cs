using LogLiteThinking.Domain.Enums;

namespace LogLiteThinking.Domain.Entities;

public class Log : Entity
{
  public string Title { get; set; }
  public string Description { get; set; }
  public int Priority { get; set; }
}