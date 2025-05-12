namespace ZadanieRekrutacyjne.Patterns;

public interface IConfigurationfor <in T>
{

}

public class StorageConfig(string connString, string container) : IConfigurationfor<StorageRepository>
{
    public string Container { get; } = container;
    public string ConnectionString { get; } = connString;
}

public class Configuration(string connString, string container, string dbase) : IConfigurationfor<CosmosRepository>
{
    public string Container { get; } = container;
    public string ConnectionString { get; } = connString;
    public string Dbase { get; } = dbase;
}
