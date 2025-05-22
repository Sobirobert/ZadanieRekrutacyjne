using Cosmonaut.Extensions;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class StorageRepository(string connString, string container, DbContext dbContext) : IRepository
   
    
{
    private readonly DbContext _dbContext = dbContext;
    private readonly DbSet<T> _dbSet = dbContext.Set<T>();

    public async Task<T> Get<T>(Guid id) where T : class, IRepositoryObject
    {
        var objectGet = await _dbSet.FindAsync(id);
        if (objectGet != null)
        {
            return objectGet;
        }
        throw new Exception("There isn't object with that id!");
    }

    public async Task<IQueryable<T>> GetAll<T>() where T : class, IRepositoryObject
    {
        return _dbContext.Set<T>().AsQueryable();
    }

    public async Task Save<T>(T input) where T : class, IRepositoryObject
    {
        if (input != null)
        {
            await _dbSet.AddAsync(input);
            await _dbContext.SaveChangesAsync(); 
        }
        throw new Exception("Empty object!");
    }

    public async Task Update<T>( T value) where T : class, IRepositoryObject
    {
        if (value != null)
        {
            var person = Get<T>(value.Id);
            if (person == null)
            {
                await Save(value);
            }
            throw new KeyNotFoundException($"Item with id {person.Id} not found");
        }
        throw new ArgumentNullException(nameof(value));
    }

    public async Task Delete<T>(Guid id) where T : class, IRepositoryObject
    {
        var objectGet = await _dbSet.FindAsync(id);
        if (objectGet != null)
        {
            await _dbSet.Remove(objectGet);
            await _dbContext.SaveChangesAsync();
        }
        throw new Exception("There isn't object with that id!");
    }
}

