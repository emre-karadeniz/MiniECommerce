using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application.Abstractions.Authentication.Jwt;
using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Domain.Baskets;
using MiniECommerce.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Persistence.Repositories
{
    internal class BasketRepository : GenericRepository<Basket>, IBasketRepository
    {
        public BasketRepository(IAppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<Basket> GetActiveBasketAsNoTrackingAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await GetAsNoTrackingAsync(x => x.UserId == userId && x.Status == BasketStatus.Active, null, cancellationToken);
        }

        public async Task<Basket> GetActiveBasketWithBasketItemsAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            var basket = await _appDbContext.Set<Basket>()
                .Include(x => x.BasketItems)
                    .ThenInclude(bi => bi.Product)
                .Where(x => x.UserId == userId && x.Status == BasketStatus.Active)
                .FirstOrDefaultAsync(cancellationToken);
            return basket;
        }
    }
}
