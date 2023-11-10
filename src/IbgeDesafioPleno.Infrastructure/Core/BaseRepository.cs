using IbgeDesafioPleno.Domain.Core;
using IbgeDesafioPleno.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace IbgeDesafioPleno.Infrastructure.Core;

public class BaseRepository<T> : IBaseRepository<T>
    where T : Entity
{
    private readonly IbgeDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(IbgeDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }


    #region Queries
    public virtual async Task<IEnumerable<T>> GetAllAsync()
        => await _dbSet
        .AsNoTracking()
        .ToListAsync();

    public virtual async Task<IEnumerable<T>> GetManyWhereAsync(Expression<Func<T, bool>> expression)
        => await _dbSet
        .Where(expression)
        .AsNoTracking()
        .ToListAsync();

    public virtual async Task<T> GetOneAsync(Expression<Func<T, bool>> expression)
        => (await _dbSet
        .AsNoTracking()
        .FirstOrDefaultAsync(expression))!;
    #endregion 

    #region Commands
    public virtual async Task AddAsync(T entity)
         => await _dbSet.AddAsync(entity);

    public virtual void Update(T entity)
         => _dbSet.Update(entity);

    public virtual void Remove(T entity)
         => _dbSet.Remove(entity);
    #endregion
}