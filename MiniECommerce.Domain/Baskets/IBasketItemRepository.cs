using MiniECommerce.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Domain.Baskets
{
    public interface IBasketItemRepository
    {
        Task AddAsync(BasketItem entity, CancellationToken cancellationToken = default);
        void Delete(BasketItem entity);
        void Update(BasketItem entity);
        Task<BasketItem> GetAsync(Expression<Func<BasketItem, bool>> expression, IList<Expression<Func<BasketItem, object>>> includeProperties = null, CancellationToken cancellationToken = default);
        IQueryable<BasketItem> GetAll(Expression<Func<BasketItem, bool>> expression = null, IList<Expression<Func<BasketItem, object>>> includeProperties = null);
        void DeleteRange(IEnumerable<BasketItem> entities);
       
    }
}
