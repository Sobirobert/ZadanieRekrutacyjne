using Application.ServicesInterfaces;
using Domain.Interfaces;

namespace Application.Services;

public class BaseGenericService(IRepository repository) : IService
{
    private readonly IRepository _repository = repository;

    public async Task<T> GetObjectById<T>(Guid id) where T : class, IRepositoryObject
    {
        var searchingObj = await _repository.Get<T>(id);
        if (searchingObj != null)
        {
            return searchingObj;
        }
        throw new Exception("Wrong id, object with that id doesn't exist");
    }

    public async Task<IEnumerable<T>> GetAllObjects<T>() where T : class, IRepositoryObject
    {
        var allObjects = await _repository.GetAll<T>();
        return allObjects;
    }
    public async Task AddService<T>(T newObject) where T : class, IRepositoryObject
    {
        var checkObject = await _repository.Get<T>(newObject.Id);
        if (checkObject == null)
        {
            await _repository.Save(newObject);
            return checkObject;
        }
        throw new Exception("This obj exist");
    }

    public async Task UpdateObject<T>(T xupdateObject) where T : class, IRepositoryObject
    {
        var checkObject = await _repository.Get<T>(updateObject.Id);
        if (checkObject != null)
        {
            await _repository.Update(checkObject);
        }
        throw new Exception("This obj doesn't exist");
    }

    public async Task RemoveService<T>(Guid id) where T : class, IRepositoryObject
    {
        var checkObject = await _repository.Get<T>(id);
        if (checkObject != null)
        {
            await _repository.Delete<T>(id);
        }
        throw new Exception("This obj doesn't exist");
    }
}