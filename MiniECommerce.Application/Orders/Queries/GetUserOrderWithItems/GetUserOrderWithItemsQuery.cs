using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Contracts.Orders;
using MiniECommerce.Domain.Core;

namespace MiniECommerce.Application.Orders.Queries.GetUserOrderWithItems
{
    public record GetUserOrderWithItemsQuery(Guid OrderId) : IQuery<Result<UserOrderWithItemsResponse>>;
}
