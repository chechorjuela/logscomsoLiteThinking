using LogLiteThinking.Domain.Entities;
using LogLiteThinking.Infrastructure.Common.Factories;
using Microsoft.EntityFrameworkCore;

namespace LogLiteThinking.Infrastructure.ContextDb;

public class DbContextApp(DbContextOptions<DbContextApp> options) : DbContext(options), IApplicationDbContext
{
  public DbSet<Log> Log { get; set; }
}