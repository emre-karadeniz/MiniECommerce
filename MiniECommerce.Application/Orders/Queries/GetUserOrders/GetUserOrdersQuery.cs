using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Contracts.Orders;
using MiniECommerce.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Application.Orders.Queries.GetUserOrders
{
    public record GetUserOrdersQuery():IQuery<Result<List<UserOrderResponse>>>;
}
