using LogLiteThinking.Domain.Repositories;
using LogLiteThinking.Infrastructure.Common.Factories;
using LogLiteThinking.Infrastructure.ContextDb;
using Microsoft.EntityFrameworkCore;

namespace LogLiteThinking.Infrastructure.Repositories.Base;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
  protected readonly DbContextApp _context;

  protected DbSet<TEntity> Set => _context.Set<TEntity>();
  public BaseRepository(IDbContextFactory factory)
  {
    _context = (DbContextApp)factory.Create();
  }

  public virtual async Task<TEntity?> GetByIdAsync(Guid id)
  {
    return await Set.FindAsync(id);
  }

  public virtual async Task<List<TEntity>> GetAllAsync()
  {
    return await Set.ToListAsync();
  }

  public virtual async Task<TEntity> AddAsync(TEntity entity)
  {
    await Set.AddAsync(entity);
    await SaveChangesAsync();
    return entity;
  }

  public virtual async Task<TEntity> UpdateAsync(TEntity entity)
  {
    Set.Attach(entity);
    _context.Entry(entity).State = EntityState.Modified;
    await SaveChangesAsync();
    return entity;
  }

  public virtual async Task<bool> DeleteAsync(Guid id)
  {
    var entity = await GetByIdAsync(id);
    if (entity != null)
    {
      Set.Remove(entity);
      return await SaveChangesAsync();
    }
    return false;
  }

  public virtual async Task<bool> SaveChangesAsync()
  {
    return await _context.SaveChangesAsync() > 0;
  }
}