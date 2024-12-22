using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Domain.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Persistence.Repositories
{
    internal class BasketItemRepository : GenericRepository<BasketItem>, IBasketItemRepository
    {
        public BasketItemRepository(IAppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
