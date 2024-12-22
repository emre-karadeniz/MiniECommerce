using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Contracts.Orders;
using MiniECommerce.Domain.Core;

namespace MiniECommerce.Application.Orders.Queries.GetUserOrders
{
    public record GetUserOrdersQuery() : IQuery<Result<List<UserOrderResponse>>>;
}
