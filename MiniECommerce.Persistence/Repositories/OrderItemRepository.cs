using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Domain.Orders;

namespace MiniECommerce.Persistence.Repositories
{
    internal class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(IAppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<List<OrderItem>> GetProductIdsByOrderId(Guid orderId, CancellationToken cancellationToken = default)
        {
            return await GetAll(x => x.OrderId == orderId).ToListAsync();
        }
    }
}
