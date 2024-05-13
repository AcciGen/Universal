using System.Linq.Expressions;

namespace Chat.Infrastructure.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _appDbContext;

        public BaseRepository(ApplicationDbContext appDbContext)
            => _appDbContext = appDbContext;

        public async ValueTask<TEntity> AddAsync(TEntity entity)
        {
            var entry = await _appDbContext.Set<TEntity>().AddAsync(entity);
            await _appDbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async ValueTask AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _appDbContext.Set<TEntity>().AddRangeAsync(entities);
            await _appDbContext.SaveChangesAsync();
        }

        public async ValueTask<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
            => _appDbContext.Set<TEntity>().Where(predicate);

        public IQueryable<TEntity> GetAll()
            => _appDbContext.Set<TEntity>();

        public async ValueTask<TEntity> GetByIdAsync(int id)
            => await _appDbContext.Set<TEntity>().FindAsync(id);

        public async ValueTask<TEntity> RemoveAsync(TEntity entity)
        {
            var entry = _appDbContext.Set<TEntity>().Remove(entity);
            await _appDbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async ValueTask RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            _appDbContext.Set<TEntity>().RemoveRange(entities);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
