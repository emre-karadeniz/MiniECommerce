using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application.Abstractions.Authentication.Jwt;
using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Application.Core.Constants;
using MiniECommerce.Contracts.Baskets;
using MiniECommerce.Domain.Baskets;
using MiniECommerce.Domain.Core;
using MiniECommerce.Domain.Products;

namespace MiniECommerce.Application.Baskets.Queries.GetBasketItems
{
    public class GetBasketItemsQueryHandler : IQueryHandler<GetBasketItemsQuery, Result<List<BasketItemResponse>>>
    {
        private readonly IUserIdentifierProvider _userIdentifierProvider;
        private readonly IAppDbContext _appDbContext;

        public GetBasketItemsQueryHandler(IUserIdentifierProvider userIdentifierProvider, IAppDbContext appDbContext)
        {
            _userIdentifierProvider = userIdentifierProvider;
            _appDbContext = appDbContext;
        }

        public async Task<Result<List<BasketItemResponse>>> Handle(GetBasketItemsQuery request, CancellationToken cancellationToken)
        {
            var response = await (from bi in _appDbContext.Set<BasketItem>()
                                  join b in _appDbContext.Set<Basket>() on bi.BasketId equals b.Id
                                  join p in _appDbContext.Set<Product>() on bi.ProductId equals p.Id
                                  where b.Status == 0 && b.UserId == _userIdentifierProvider.UserId
                                  orderby bi.CreatedDate descending
                                  select new BasketItemResponse()
                                  {
                                      Id = bi.Id,
                                      BasketId = bi.BasketId,
                                      Quantity = bi.Quantity,
                                      ProductId = bi.ProductId,
                                      ProductName = p.Name,
                                      ProductPrice = p.Price
                                  }).AsNoTracking().ToListAsync(cancellationToken);

            return Result<List<BasketItemResponse>>.Success(Messages.Common.Success, response);
        }
    }
}
