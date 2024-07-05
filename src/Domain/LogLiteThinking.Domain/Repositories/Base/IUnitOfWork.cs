namespace LogLiteThinking.Domain.Repositories;

public interface IUnitOfWork<TEntity> : IDisposable where TEntity : class
{
  IBaseRepository<TEntity> Repository { get; }
  Task<int> SaveChangesAsync();
}