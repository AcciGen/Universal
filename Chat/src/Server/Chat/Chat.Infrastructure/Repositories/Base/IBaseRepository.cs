using System.Linq.Expressions;

namespace Chat.Infrastructure.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> GetByIdAsync(int id);
        IQueryable<TEntity> GetAll();
        ValueTask<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        ValueTask<TEntity> AddAsync(TEntity entity);
        ValueTask<TEntity> RemoveAsync(TEntity entity);
        ValueTask AddRangeAsync(IEnumerable<TEntity> entities);
        ValueTask RemoveRangeAsync(IEnumerable<TEntity> entities);
    }
}
