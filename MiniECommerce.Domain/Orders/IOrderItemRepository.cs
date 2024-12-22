using MiniECommerce.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Domain.Orders
{
    public interface IOrderItemRepository
    {
        Task AddRangeAsync(IEnumerable<OrderItem> entities, CancellationToken cancellationToken = default);
    }
}
