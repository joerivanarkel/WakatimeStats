using Common.Exceptions;
using Common.Models.Interface;
using DataAccess;

namespace DataAccess.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> 
    where T : class, IEntity 
{
    protected DatabaseContext Database;

    protected BaseRepository(DatabaseContext databaseContext)
    {
        Database = databaseContext;
    }

    public virtual bool Add(T entity)
    {
        Database.Set<T>().Add(entity);
        return Database.SaveChanges() > 0;
    }

    public virtual bool AddRange(IEnumerable<T> entities)
    {
        Database.Set<T>().AddRange(entities);
        return Database.SaveChanges() > 0;
    }

    public virtual bool Update(T entity)
    {
        Database.Set<T>().Update(entity);
        return Database.SaveChanges() > 0;
    }

    public virtual bool Remove(int id)
    {
        var entity = Database.Set<T>().Find(id) 
            ?? throw new RepositoryException("Entity not found");
        Database.Set<T>().Remove(entity);
        return Database.SaveChanges() > 0;
    }

    public virtual T Get(int id)
    {
        var entity = Database.Set<T>().Find(id) 
            ?? throw new RepositoryException("Entity not found");
        return entity;
    }

    public virtual IEnumerable<T> GetAll()
    {
        return Database.Set<T>().ToList();
    }
}
