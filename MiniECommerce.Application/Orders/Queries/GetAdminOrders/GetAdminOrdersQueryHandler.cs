using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Application.Core.Constants;
using MiniECommerce.Contracts.Orders;
using MiniECommerce.Domain.Core;
using MiniECommerce.Domain.Orders;

namespace MiniECommerce.Application.Orders.Queries.GetAdminOrders
{
    public class GetAdminOrdersQueryHandler : IQueryHandler<GetAdminOrdersQuery, Result<List<AdminOrderResponse>>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetAdminOrdersQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Result<List<AdminOrderResponse>>> Handle(GetAdminOrdersQuery request, CancellationToken cancellationToken)
        {
            var response = await _appDbContext.Set<Order>()
                .Include(o => o.User)
                .OrderByDescending(o => o.CreatedDate)
                .Select(o => new AdminOrderResponse()
                {
                    Id = o.Id,
                    UserId = o.User.Id,
                    FullName = o.User.FirstName + " " + o.User.LastName,
                    Status = o.Status.ToString(),
                    TotalPrice = o.TotalPrice,
                    CreatedDate = o.CreatedDate
                }).AsNoTracking().ToListAsync();

            return Result<List<AdminOrderResponse>>.Success(Messages.Common.Success, response);
        }
    }
}
