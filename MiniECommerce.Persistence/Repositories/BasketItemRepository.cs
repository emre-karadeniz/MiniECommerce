using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Domain.Baskets;

namespace MiniECommerce.Persistence.Repositories
{
    internal class BasketItemRepository : GenericRepository<BasketItem>, IBasketItemRepository
    {
        public BasketItemRepository(IAppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
