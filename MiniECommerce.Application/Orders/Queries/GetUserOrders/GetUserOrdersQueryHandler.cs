using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application.Abstractions.Authentication.Jwt;
using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Application.Core.Constants;
using MiniECommerce.Contracts.Orders;
using MiniECommerce.Domain.Core;
using MiniECommerce.Domain.Orders;

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
                .Where(o => o.UserId == _userIdentifierProvider.UserId)
                .OrderByDescending(o => o.CreatedDate)
                .Select(o => new UserOrderResponse()
                {
                    Id = o.Id,
                    Status = o.Status.ToString(),
                    TotalPrice = o.TotalPrice,
                    CreatedDate = o.CreatedDate
                }).AsNoTracking().ToListAsync();

            return Result<List<UserOrderResponse>>.Success(Messages.Common.Success, response);
        }
    }
}
