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
                .Include(x => x.User)
                .OrderByDescending(x => x.CreatedDate)
                .Select(x => new AdminOrderResponse()
                {
                    Id = x.Id,
                    UserId = x.User.Id,
                    FullName = x.User.FirstName + " " + x.User.LastName,
                    Status = x.Status.ToString(),
                    TotalPrice = x.TotalPrice,
                    CreatedDate = x.CreatedDate
                }).ToListAsync();

            return Result<List<AdminOrderResponse>>.Success("", response);
        }
    }
}
