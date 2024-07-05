using LogLiteThinking.Infrastructure.ContextDb;
using Microsoft.EntityFrameworkCore;

namespace LogLiteThinking.Infrastructure.Common.Factories;

public class ApplicationDbContextFactory : IDbContextFactory
{
  private readonly DbContextOptions<DbContextApp> options;

  public ApplicationDbContextFactory(DbContextOptions<DbContextApp> options)
  {
    this.options = options;
  }

  public DbContext Create()
  {
    return new DbContextApp(this.options);
  }
}