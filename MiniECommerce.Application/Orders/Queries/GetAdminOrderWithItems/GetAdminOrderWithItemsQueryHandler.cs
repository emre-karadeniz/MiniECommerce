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

namespace MiniECommerce.Application.Orders.Queries.GetAdminOrderWithItems
{
    public class GetAdminOrderWithItemsQueryHandler : IQueryHandler<GetAdminOrderWithItemsQuery, Result<AdminOrderWithItemsResponse>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetAdminOrderWithItemsQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Result<AdminOrderWithItemsResponse>> Handle(GetAdminOrderWithItemsQuery request, CancellationToken cancellationToken)
        {
            var response = await _appDbContext.Set<Order>()
                .Where(x => x.Id == request.OrderId)
                .Include(x=>x.OrderItems)
                .Include(x=>x.User)
                .OrderByDescending(x => x.CreatedDate)
                .Select(x => new AdminOrderWithItemsResponse()
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    FullName= x.User.FirstName + " " + x.User.LastName,
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

            return Result<AdminOrderWithItemsResponse>.Success("", response);
        }
    }
}
