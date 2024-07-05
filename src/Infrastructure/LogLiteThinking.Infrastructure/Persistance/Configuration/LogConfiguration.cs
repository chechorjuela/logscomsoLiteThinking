using LogLiteThinking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogLiteThinking.Infrastructure.ContextDb.Configuration;

public class LogConfiguration : IEntityTypeConfiguration<Log>
{
  public void Configure(EntityTypeBuilder<Log> builder)
  {
    builder.ToTable("Log");
    builder.HasKey(l => l.Id);
    builder.Property(t => t.Id)
      .IsRequired();
  }
}