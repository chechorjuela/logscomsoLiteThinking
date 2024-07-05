using System.Reflection;
using LogLiteThinking.Application.Common.Behaviours;
using LogLiteThinking.Application.Features.Logs.Queries.GetLogsAll;
using LogLiteThinking.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LogLiteThinking.Application;

public static class DependecyInjectionApplication
{
  public static IServiceCollection AddApplicationServices(
    this IServiceCollection services,
    IConfiguration configuration)
  {
   

    services.AddInfrastructure(configuration);

    //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), ServiceLifetime.Transient);
    
    services.AddAutoMapper(Assembly.GetExecutingAssembly());
    services.AddScoped<GetLogsAllQuery.GetLogsAllQueryHandler>();
    services.AddMediatR(cfg =>
    {
      cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
      cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
    });

    
    return services;
  }
}