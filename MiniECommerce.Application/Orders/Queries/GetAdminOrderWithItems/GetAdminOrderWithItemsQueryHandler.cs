using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Application.Core.Constants;
using MiniECommerce.Contracts.Orders;
using MiniECommerce.Domain.Core;
using MiniECommerce.Domain.Orders;

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
                .Where(o => o.Id == request.OrderId)
                .Include(o => o.OrderItems)
                .Include(o => o.User)
                .OrderByDescending(o => o.CreatedDate)
                .Select(o => new AdminOrderWithItemsResponse()
                {
                    Id = o.Id,
                    UserId = o.UserId,
                    FullName = o.User.FirstName + " " + o.User.LastName,
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

            return Result<AdminOrderWithItemsResponse>.Success(Messages.Common.Success, response);
        }
    }
}
