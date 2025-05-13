using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class CosmosRepository(string connString, string dbase,string container) : IRepository
{
    Task IRepository.Delete<T>(Guid id)
    {
        throw new NotImplementedException();
    }

    Task<T> IRepository.Get<T>(Guid id)
    {
        throw new NotImplementedException();
    }

    Task<T> IRepository.GetAll<T>()
    {
        throw new NotImplementedException();
    }

    Task IRepository.Save<T>(T inpust)
    {
        throw new NotImplementedException();
    }

    Task IRepository.Update<T>(Guid id, T inpust)
    {
        throw new NotImplementedException();
    }
}
