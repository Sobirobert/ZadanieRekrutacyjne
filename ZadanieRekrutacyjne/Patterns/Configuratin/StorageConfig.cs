using Infrastructure.Repositories;

namespace ZadanieRekrutacyjne.Patterns.Configuratin;

public class StorageConfig(string connString, string container) : IConfigurationfor<StorageRepository>
{
    public string Container { get; } = container;
    public string ConnectionString { get; } = connString;
}
