using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Domain.Baskets;
using MiniECommerce.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Persistence.Repositories
{
    internal class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(IAppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
