using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Domain.Core;
using System.Linq.Expressions;

namespace MiniECommerce.Persistence.Repositories
{
    internal abstract class GenericRepository<TEntity>
        where TEntity : Entity
    {
        protected readonly IAppDbContext _appDbContext;

        public GenericRepository(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _appDbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await _appDbContext.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _appDbContext.Set<TEntity>().AnyAsync(expression, cancellationToken);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> expression = null, CancellationToken cancellationToken = default)
        {
            return await _appDbContext.Set<TEntity>().CountAsync(expression, cancellationToken);
        }

        public void Delete(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _appDbContext.Set<TEntity>().RemoveRange(entities);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null, IList<Expression<Func<TEntity, object>>> includeProperties = null)
        {
            IQueryable<TEntity> query = _appDbContext.Set<TEntity>();

            if (includeProperties != null && includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            if (expression != null)
            {
                query = query.Where(expression);
            }

            return query.AsNoTracking();
        }

        public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _appDbContext.Set<TEntity>().FindAsync(id, cancellationToken);
        }

        public void Update(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Update(entity);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, IList<Expression<Func<TEntity, object>>> includeProperties = null, CancellationToken cancellationToken=default)
        {
            IQueryable<TEntity> query = _appDbContext.Set<TEntity>();

            if (includeProperties != null && includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.FirstOrDefaultAsync(expression, cancellationToken);
        }

        public async Task<TEntity> GetAsNoTrackingAsync(Expression<Func<TEntity, bool>> expression, IList<Expression<Func<TEntity, object>>> includeProperties = null, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _appDbContext.Set<TEntity>();

            if (includeProperties != null && includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(expression, cancellationToken);
        }
    }
}
