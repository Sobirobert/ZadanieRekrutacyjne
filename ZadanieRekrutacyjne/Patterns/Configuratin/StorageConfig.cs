using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ZadanieRekrutacyjne.Patterns.Configuratin;

public class StorageConfig(string connString, string container, DbContext dbContext) : IConfigurationfor<StorageRepository>
{
    public string Container { get; } = container;
    public string ConnectionString { get; } = connString;
    public DbContext DbContext { get; } = dbContext;
}
