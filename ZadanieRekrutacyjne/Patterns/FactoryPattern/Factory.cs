using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using ZadanieRekrutacyjne.Patterns.Configuratin;

namespace ZadanieRekrutacyjne.Patterns.FactoryPattern;

public class Factory
{
    public static T Create<T>(IConfigurationfor<T> config) where T : class, IRepository
    {
        switch (config)
        {
            case StorageConfig storageConfig:
                return new StorageRepository(storageConfig.ConnectionString, storageConfig.Container, storageConfig.dbContext) as T;

            case CosmosConfig cosmosConfig:
                return new CosmosRepository(cosmosConfig.ConnectionString, cosmosConfig.Dbase, cosmosConfig.Container) as T;
            default:
                throw new Exception("Wrong value");
        }

    }
}
