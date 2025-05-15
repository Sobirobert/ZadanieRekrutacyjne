using Domain.Interfaces;

namespace Application.ServicesInterfaces;

public interface IService
{
    Task<T> GetObjectById<T>(Guid id) where T : class, IRepositoryObject;
    Task<IEnumerable<T>> GetAllObjects<T>() where T : class, IRepositoryObject;
    Task AddService<T>(T newObject) where T : class, IRepositoryObject;
    Task UpdateObject<T>(T updateObject) where T : class, IRepositoryObject;
    Task RemoveService<T>(Guid id) where T : class, IRepositoryObject;
}
