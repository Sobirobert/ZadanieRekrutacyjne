using Infrastructure.Repositories;

namespace ZadanieRekrutacyjne.Patterns.Configuratin;
public class CosmosConfig(string connString, string container, string dbase) : IConfigurationfor<CosmosRepository>
{
    public string Container { get; } = container;
    public string ConnectionString { get; } = connString;
    public string Dbase { get; } = dbase;
}
