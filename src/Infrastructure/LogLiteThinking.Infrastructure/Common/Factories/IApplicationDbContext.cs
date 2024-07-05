using LogLiteThinking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogLiteThinking.Infrastructure.Common.Factories;

public interface IApplicationDbContext
{
 
    DbSet<Log> Log { get; set;  }

}