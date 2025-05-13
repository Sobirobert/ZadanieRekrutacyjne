namespace Application.ServicesInterfaces;

public interface IService
{
    Task<T> Get<T>(Guid id)
    {
        throw new NotImplementedException();
    }

    Task<T> GetAll<T>()
    {
        throw new NotImplementedException();
    }

    Task Save<T>(T inpust)
    {
        throw new NotImplementedException();
    }

    Task<T> Update<T>(Guid id, T value)
    {
        throw new NotImplementedException();
    }

    public Task Delete<T>(Guid id)
    {
        throw new NotImplementedException();
    }
}
