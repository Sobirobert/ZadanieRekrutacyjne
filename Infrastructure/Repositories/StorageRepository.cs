using Cosmonaut.Extensions;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class StorageRepository(string connString, string container, DbContext DbContext, DbSet<T> DbSet) : IRepository
{
    private readonly DbContext dbContext = DbContext;
    private readonly DbSet<T> dbSet = DbContext.Set<T>();

    public async Task<T> Get<T>(Guid id) where T : class, IRepositoryObject
    {
        var objectGet = await dbSet.FindAsync(id);
        if (objectGet != null)
        {
            return objectGet;
        }
        throw new Exception("There isn't object with that id!");
    }

    public async Task<IQueryable<T>> GetAll<T>() where T : class, IRepositoryObject
    {
        return await dbSet.ToListAsync();
    }

    public async Task Save<T>(T input) where T : class, IRepositoryObject
    {
        if (input != null)
        {
            await dbSet.AddAsync(input);
            await dbContext.SaveChangesAsync(); 
        }
        throw new Exception("Empty object!");
    }

    public async Task<T> Update<T>(Guid id, T value) where T : class, IRepositoryObject
    {
        throw new NotImplementedException();
    }

    public async Task Delete<T>(Guid id) where T : class, IRepositoryObject
    {
        var objectGet = await dbSet.FindAsync(id);
        if (objectGet != null)
        {
            await dbSet.Remove(objectGet);
            await dbContext.SaveChangesAsync();
        }
        throw new Exception("There isn't object with that id!");
    }
}

