using LogLiteThinking.Domain.Entities;

namespace LogLiteThinking.Domain.Repositories;

public interface ILogRepository : IBaseRepository<Log>
{
  Task<List<Log>> FilterByPrority(int priority);
}