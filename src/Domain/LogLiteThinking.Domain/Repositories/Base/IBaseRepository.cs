namespace LogLiteThinking.Domain.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
  Task<TEntity> GetByIdAsync(Guid id);
  Task<List<TEntity>> GetAllAsync();
  Task<TEntity> AddAsync(TEntity entity);
  Task<TEntity> UpdateAsync(TEntity entity);
  Task<bool> DeleteAsync(Guid id);
  Task<bool> SaveChangesAsync();
}