namespace ZadanieRekrutacyjne.Patterns;

public class Factory
{
    public static T Create<T>(IConfiguration<T> config) where T : class, IReposistory
    {
        switch(config)
            {
            case StorageConfig storageConfig:
                return new StorageRepository(storageConfig.ConnectionString, storageConfig.Container) as T;

            case Configuration cosmosConfig:
                return new CosmosRepository(cosmosConfig.ConnectionString,cosmosConfig.Dbase, cosmosConfig.Container) as T;
            }

    }
}
