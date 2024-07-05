using LogLiteThinking.Domain.Repositories;
using LogLiteThinking.Infrastructure.Common.Factories;
using LogLiteThinking.Infrastructure.ContextDb;

namespace LogLiteThinking.Infrastructure.Repositories.Base;

public class UnitOfWork<TEntity> : IUnitOfWork<TEntity> where TEntity : class
{
  public IBaseRepository<TEntity> Repository { get; }

  private readonly DbContextApp _context;

  public UnitOfWork(IDbContextFactory factory)
  {
    _context = (DbContextApp)factory.Create();
    Repository = new BaseRepository<TEntity>(factory);

  }
  public async Task<int> SaveChangesAsync()
  {
    return await _context.SaveChangesAsync();
  }

  public void Dispose()
  {
    _context.Dispose();
  }
}