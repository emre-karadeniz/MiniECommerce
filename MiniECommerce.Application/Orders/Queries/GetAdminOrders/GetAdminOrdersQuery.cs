using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Contracts.Orders;
using MiniECommerce.Domain.Core;

namespace MiniECommerce.Application.Orders.Queries.GetAdminOrders
{
    public record GetAdminOrdersQuery() : IQuery<Result<List<AdminOrderResponse>>>;
}
