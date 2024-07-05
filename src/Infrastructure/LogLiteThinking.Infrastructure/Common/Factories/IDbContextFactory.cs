using Microsoft.EntityFrameworkCore;

namespace LogLiteThinking.Infrastructure.Common.Factories;

public interface IDbContextFactory
{
  DbContext Create();
}