namespace Domain.Interfaces;

public interface IRepository
{
    Task<T> Get<T>(Guid id) where T : class, IRepositoryObject;
    Task<T> GetAll<T>() where T : class, IRepositoryObject;
    Task Save<T>(T inpust) where T : class, IRepositoryObject;
    Task Update<T>(Guid id, T inpust) where T : class, IRepositoryObject;
    Task Delete<T>(Guid id)where T : class, IRepositoryObject;
}
