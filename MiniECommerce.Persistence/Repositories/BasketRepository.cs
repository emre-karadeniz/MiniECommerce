using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Domain.Baskets;

namespace MiniECommerce.Persistence.Repositories
{
    internal class BasketRepository : GenericRepository<Basket>, IBasketRepository
    {
        public BasketRepository(IAppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<Basket> GetActiveBasketAsNoTrackingAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await GetAsNoTrackingAsync(b => b.UserId == userId && b.Status == BasketStatus.Active, null, cancellationToken);
        }

        public async Task<Basket> GetActiveBasketWithBasketItemsAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            var basket = await _appDbContext.Set<Basket>()
                .Include(b => b.BasketItems)
                    .ThenInclude(bi => bi.Product)
                .Where(b => b.UserId == userId && b.Status == BasketStatus.Active)
                .FirstOrDefaultAsync(cancellationToken);
            return basket;
        }
    }
}
