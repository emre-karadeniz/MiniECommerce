using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Domain.Products;

namespace MiniECommerce.Persistence.Repositories
{
    internal class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(IAppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductsByIdsAsync(List<Guid> productIds)
        {
            var products = await _appDbContext.Set<Product>()
                                  .Where(p => productIds.Contains(p.Id))
                                  .ToListAsync();

            return products;
        }
    }
}
