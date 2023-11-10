using System.Linq.Expressions;

namespace IbgeDesafioPleno.Domain.Core;

public interface IBaseRepository<T> 
    where T : Entity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetManyWhereAsync(Expression<Func<T, bool>> expression);
    Task<T> GetOneAsync(Expression<Func<T, bool>> expression);

    Task AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
}