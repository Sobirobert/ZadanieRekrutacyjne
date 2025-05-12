namespace ZadanieRekrutacyjne.Patterns;
public interface IRepositoryObject;
public interface IReposistory
{
    public Task<T> Get<T>(Guid id) where T : class, IRepositoryObject;
    public Task Save<T>(T inpust) where T : class, IRepositoryObject;

}

public class StorageRepository(string connString, string container) : IReposistory
{
    Task<T> IReposistory.Get<T>(Guid id)
    {
        throw new NotImplementedException();
    }

    Task IReposistory.Save<T>(T inpust)
    {
        throw new NotImplementedException();
    }
}

public class CosmosRepository(string connString, string dbase,string container) : IReposistory
{
    Task<T> IReposistory.Get<T>(Guid id)
    {
        throw new NotImplementedException();
    }

    Task IReposistory.Save<T>(T inpust)
    {
        throw new NotImplementedException();
    }
}
