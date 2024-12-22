using MiniECommerce.Domain.Core;
using System.Linq.Expressions;

namespace MiniECommerce.Domain.Products
{
    public interface IProductRepository
    {
        Task AddAsync(Product entity, CancellationToken cancellationToken = default);
        void Update(Product entity);
        Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        void Delete(Product entity);
        IQueryable<Product> GetAll(Expression<Func<Product, bool>> expression = null, IList<Expression<Func<Product, object>>> includeProperties = null);
        Task<bool> AnyAsync(Expression<Func<Product, bool>> expression, CancellationToken cancellationToken = default);
        Task<List<Product>> GetProductsByIdsAsync(List<Guid> productIds);
    }
}
