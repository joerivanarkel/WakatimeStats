using Common.Models.Interface;

namespace DataAccess;

public interface IBaseRepository<T> where T : class, IEntity
{
    bool Add(T entity);
    bool AddRange(IEnumerable<T> entities);
    bool Update(T entity);
    bool Remove(int id);
    T Get(int id);
    IEnumerable<T> GetAll();
}
