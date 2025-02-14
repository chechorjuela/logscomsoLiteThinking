namespace LogLiteThinking.Domain.Entities;

public abstract class Entity
{
  public Guid Id { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.Today;
}