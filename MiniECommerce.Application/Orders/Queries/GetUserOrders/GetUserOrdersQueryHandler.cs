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

namespace MiniECommerce.Application.Orders.Queries.GetUserOrders
{
    public class GetUserOrdersQueryHandler : IQueryHandler<GetUserOrdersQuery, Result<List<UserOrderResponse>>>
    {
        private readonly IUserIdentifierProvider _userIdentifierProvider;
        private readonly IAppDbContext _appDbContext;

        public GetUserOrdersQueryHandler(IUserIdentifierProvider userIdentifierProvider, IAppDbContext appDbContext)
        {
            _userIdentifierProvider = userIdentifierProvider;
            _appDbContext = appDbContext;
        }

        public async Task<Result<List<UserOrderResponse>>> Handle(GetUserOrdersQuery request, CancellationToken cancellationToken)
        {
            var response = await _appDbContext.Set<Order>()
                .Where(x => x.UserId == _userIdentifierProvider.UserId)
                .OrderByDescending(x => x.CreatedDate)
                .Select(x => new UserOrderResponse()
                {
                    Id = x.Id,
                    Status = x.Status.ToString(),
                    TotalPrice = x.TotalPrice,
                    CreatedDate = x.CreatedDate
                }).ToListAsync();

            return Result<List<UserOrderResponse>>.Success("", response);
        }
    }
}
