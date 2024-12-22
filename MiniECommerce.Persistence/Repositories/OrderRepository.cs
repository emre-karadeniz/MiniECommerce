using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Domain.Baskets;
using MiniECommerce.Domain.Orders;
using MiniECommerce.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Persistence.Repositories
{
    internal class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(IAppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<Order> GetOrderByIdAndUserIdAsync(Guid id, Guid userId, CancellationToken cancellationToken = default)
        {
            return await GetAsync(x => x.Id == id && x.UserId == userId && x.Status==OrderStatus.Created);
        }

        public async Task<Order> GetOrderByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await GetAsync(x => x.Id == id  && x.Status == OrderStatus.Created);
        }
    }
}
