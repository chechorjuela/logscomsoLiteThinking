using LogLiteThinking.Domain.Entities;
using LogLiteThinking.Domain.Repositories;
using LogLiteThinking.Infrastructure.Common.Factories;
using LogLiteThinking.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace LogLiteThinking.Infrastructure.Repositories;

public class LogRepository : BaseRepository<Log>, ILogRepository
{
  public LogRepository(IDbContextFactory context) : base(context)
  {
  }

  public async Task<List<Log>> FilterByPrority(int priority)
  {
    return await _context.Log.Where(l => l.Priority == priority).ToListAsync();
  }
}