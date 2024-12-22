using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Contracts.Orders;
using MiniECommerce.Domain.Core;

namespace MiniECommerce.Application.Orders.Queries.GetAdminOrderWithItems
{
    public record GetAdminOrderWithItemsQuery(Guid OrderId) : IQuery<Result<AdminOrderWithItemsResponse>>;
}
