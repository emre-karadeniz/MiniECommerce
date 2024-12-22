using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application.Abstractions.Authentication.Jwt;
using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Contracts.Orders;
using MiniECommerce.Domain.Core;
using MiniECommerce.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .Where(x => x.UserId == _userIdentifierProvider.UserId && x.Id == request.OrderId)
                .Include(x=>x.OrderItems)
                .OrderByDescending(x => x.CreatedDate)
                .Select(x => new UserOrderWithItemsResponse()
                {
                    Id = x.Id,
                    Status = x.Status.ToString(),
                    TotalPrice = x.TotalPrice,
                    CreatedDate = x.CreatedDate,
                    OrderItems =x.OrderItems.Select(i => new OrderItemResponse()
                    {
                        Id=i.Id,
                        ProductId = i.ProductId,
                        ProductName = i.ProductName,
                        ProductPrice = i.ProductPrice,
                        Quantity = i.Quantity
                    }).ToList()
                }).FirstOrDefaultAsync();

            return Result<UserOrderWithItemsResponse>.Success("", response);
        }
    }
}
