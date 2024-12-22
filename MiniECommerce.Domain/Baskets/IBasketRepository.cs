using System.Linq.Expressions;

namespace MiniECommerce.Domain.Baskets
{
    public interface IBasketRepository
    {
        Task AddAsync(Basket entity, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(Expression<Func<Basket, bool>> expression, CancellationToken cancellationToken = default);
        Task<Basket> GetActiveBasketWithBasketItemsAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<Basket> GetActiveBasketAsNoTrackingAsync(Guid userId, CancellationToken cancellationToken = default);
    }
}
