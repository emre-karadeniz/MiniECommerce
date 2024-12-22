using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Domain.Orders;

namespace MiniECommerce.Persistence.Repositories
{
    internal class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(IAppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
