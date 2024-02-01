
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();

    Task<(int totalRegistros, IEnumerable<T> registros)> GetAllAsync(int pageIndex, int pageSize, string search);
    IEnumerable<T> FindAsync(Expression<Func<T, bool>> predicate);
    Task<(int totalRegistros, IEnumerable<T> registros)> FindAsyncPaginated(Expression<Func<T, bool>> expression, int pageIndex, int pageSize);

    T Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    void Update(T entity);
    
}


