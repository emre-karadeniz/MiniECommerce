using MiniECommerce.Domain.Core;
using MiniECommerce.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Domain.Baskets
{
    public interface IBasketRepository
    {
        Task AddAsync(Basket entity, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(Expression<Func<Basket, bool>> expression, CancellationToken cancellationToken = default);
        Task<Basket> GetActiveBasketWithBasketItemsAsync(Guid userId, CancellationToken cancellationToken=default);
        Task<Basket> GetActiveBasketAsNoTrackingAsync(Guid userId, CancellationToken cancellationToken = default);
    }
}
