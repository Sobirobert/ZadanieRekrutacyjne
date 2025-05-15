using Domain.Interfaces;
using Microsoft.Azure.Cosmos;

namespace Infrastructure.Repositories;

public class CosmosRepository( string connString, string dbase, string container) : IRepository
{
    private readonly CosmosClient _cosmosClient = new CosmosClient(connString);
    private readonly string _databaseName = dbase;
    private readonly string _containerName = container;
    private Database _database;
    private Container _container;

    private async Task InitializeAsync()
    {
            _database = await _cosmosClient.CreateDatabaseIfNotExistsAsync(_databaseName);
            _container = await _database.CreateContainerIfNotExistsAsync(
            id: _containerName,
            partitionKeyPath: "/id",
            throughput: 400 
        );
    }

    public async Task<T> Get<T>(Guid id) where T : class, IRepositoryObject
    {
        try
        {
            var stringId = id.ToString();

            ItemResponse<T> response = await _container.ReadItemAsync<T>(
                id: stringId,
                partitionKey: new PartitionKey(stringId)
            );

            return response.Resource;
        }
        catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }
    }

    public async Task<IQueryable<T>> GetAll<T>() where T : class, IRepositoryObject
    {
        // Dodajemy filtr po typie
        string typeName = typeof(T).Name;
        string query = $"SELECT * FROM c WHERE c.type = '{typeName}'";

        List<T> results = new List<T>();

        using (FeedIterator<T> resultSetIterator = _container.GetItemQueryIterator<T>(
            queryDefinition: new QueryDefinition(query)))
        {
            while (resultSetIterator.HasMoreResults)
            {
                FeedResponse<T> response = await resultSetIterator.ReadNextAsync();
                results.AddRange(response);
            }
        }

        return results;
    }

    public async Task Save<T>(T input) where T : class, IRepositoryObject
    {
        if (input != null)
        {
            if (input.Id == Guid.Empty)
            {
                input.Id = Guid.NewGuid();
            }

            dynamic itemToSave = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(
                Newtonsoft.Json.JsonConvert.SerializeObject(input));
            itemToSave.type = typeof(T).Name;

            var stringId = input.Id.ToString();

            await _container.UpsertItemAsync<dynamic>(
                item: itemToSave,
                partitionKey: new PartitionKey(stringId)
            );
        }
        throw new ArgumentNullException(nameof(input));
    }

    public async Task<T> Update<T>(Guid id, T value) where T : class, IRepositoryObject
    {
        if (value != null)
        {
            bool equalsObject = (value.Id = id) ? true : false;
            var existingItem = await Get<T>(id);
            if (existingItem != null || equalsObject)
            {
                await Save(value);
                return value;
            }
            throw new KeyNotFoundException($"Item with id {id} not found");
        }
        throw new ArgumentNullException(nameof(value));
    }

    public async Task Delete<T>(Guid id) where T : class, IRepositoryObject
    {
        try
        {
            var stringId = id.ToString();

            await _container.DeleteItemAsync<T>(
                id: stringId,
                partitionKey: new PartitionKey(stringId)
            );
        }
        catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            Console.WriteLine(ex.Message );
        }
    }
}
