using System.Configuration;
using LogLiteThinking.Domain.Entities;
using LogLiteThinking.Domain.Repositories;
using LogLiteThinking.Infrastructure.Common.Factories;
using LogLiteThinking.Infrastructure.ContextDb;
using LogLiteThinking.Infrastructure.Repositories;
using LogLiteThinking.Infrastructure.Repositories.Base;
using LogLiteThinking.Infrastructure.Utils;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LogLiteThinking.Infrastructure;

public static class DependecyInjections
{
  public static IServiceCollection AddInfrastructure(
    this IServiceCollection services,
    IConfiguration configuration
  )
  {
    string cosmosEndpoint = configuration["AzureCosmoDb:Uri"];
    string cosmosKey = configuration["AzureCosmoDb:AccountKey"];
    string databaseName = configuration["AzureCosmoDb:DatabaseName"];
    string containerName = configuration["AzureCosmoDb:ContainerName"];

    var connectionString = configuration.GetConnectionString("ConnectionString");

    services.AddSingleton(serviceProvider =>
    {
      return new CosmosClient(cosmosEndpoint, cosmosKey);
    });

    // Configure Cosmos DB service singleton
    services.AddSingleton<CosmoService>(serviceProvider =>
    {
      var client = serviceProvider.GetRequiredService<CosmosClient>();
      return new CosmoService(client, databaseName, containerName);
    });



    services.AddDbContext<DbContextApp>((sp, options) =>
    {
      options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
      options.UseSqlServer(connectionString);
    }, ServiceLifetime.Scoped);

    services.AddTransient<IDbContextFactory, ApplicationDbContextFactory>(s =>
    {
      var connectionString = configuration.GetConnectionString("ConnectionString");

      var options = new DbContextOptionsBuilder<DbContextApp>().UseSqlServer(
          connectionString,
          b =>
          {
            b.MigrationsAssembly(typeof(DbContextApp).Assembly.FullName);
            b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
          })
        .Options;
      return new ApplicationDbContextFactory(options);
    });

    services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
    services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
    services.AddTransient<ILogRepository, LogRepository>();

    services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<DbContextApp>());

    services.AddSingleton(TimeProvider.System);

    return services;
  }
}