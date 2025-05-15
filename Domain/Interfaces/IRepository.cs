namespace Domain.Interfaces;

public interface IRepository
{
    Task<T> Get<T>(Guid id) where T : class, IRepositoryObject;
    Task Save<T>(T input) where T : class, IRepositoryObject;
    Task<IQueryable<T>> GetAll<T>() where T : class, IRepositoryObject;
    Task<T> Update<T>(Guid id, T value) where T : class, IRepositoryObject;
    Task Delete<T>(Guid id) where T : class, IRepositoryObject;
}
