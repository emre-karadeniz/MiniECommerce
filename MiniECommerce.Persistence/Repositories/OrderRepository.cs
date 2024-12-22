using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Domain.Orders;

namespace MiniECommerce.Persistence.Repositories
{
    internal class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(IAppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<Order> GetOrderByIdAndUserIdAsync(Guid id, Guid userId, CancellationToken cancellationToken = default)
        {
            return await GetAsync(o => o.Id == id && o.UserId == userId && o.Status == OrderStatus.Created);
        }

        public async Task<Order> GetOrderByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await GetAsync(o => o.Id == id && o.Status == OrderStatus.Created);
        }
    }
}
