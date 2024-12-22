using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application.Abstractions.Authentication.Jwt;
using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Application.Core.Constants;
using MiniECommerce.Contracts.Orders;
using MiniECommerce.Domain.Core;
using MiniECommerce.Domain.Orders;

namespace MiniECommerce.Application.Orders.Queries.GetUserOrderWithItems
{
    public class GetUserOrderWithItemsQueryHandler : IQueryHandler<GetUserOrderWithItemsQuery, Result<UserOrderWithItemsResponse>>
    {
        private readonly IUserIdentifierProvider _userIdentifierProvider;
        private readonly IAppDbContext _appDbContext;

        public GetUserOrderWithItemsQueryHandler(IUserIdentifierProvider userIdentifierProvider, IAppDbContext appDbContext)
        {
            _userIdentifierProvider = userIdentifierProvider;
            _appDbContext = appDbContext;
        }

        public async Task<Result<UserOrderWithItemsResponse>> Handle(GetUserOrderWithItemsQuery request, CancellationToken cancellationToken)
        {
            var response = await _appDbContext.Set<Order>()
                .Where(o => o.UserId == _userIdentifierProvider.UserId && o.Id == request.OrderId)
                .Include(o => o.OrderItems)
                .OrderByDescending(o => o.CreatedDate)
                .Select(o => new UserOrderWithItemsResponse()
                {
                    Id = o.Id,
                    Status = o.Status.ToString(),
                    TotalPrice = o.TotalPrice,
                    CreatedDate = o.CreatedDate,
                    OrderItems = o.OrderItems.Select(i => new OrderItemResponse()
                    {
                        Id = i.Id,
                        ProductId = i.ProductId,
                        ProductName = i.ProductName,
                        ProductPrice = i.ProductPrice,
                        Quantity = i.Quantity
                    }).ToList()
                }).AsNoTracking().FirstOrDefaultAsync();

            return Result<UserOrderWithItemsResponse>.Success(Messages.Common.Success, response);
        }
    }
}
