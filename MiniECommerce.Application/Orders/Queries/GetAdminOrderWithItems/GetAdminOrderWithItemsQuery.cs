using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Contracts.Orders;
using MiniECommerce.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Application.Orders.Queries.GetAdminOrderWithItems
{
    public record GetAdminOrderWithItemsQuery(Guid OrderId):IQuery<Result<AdminOrderWithItemsResponse>>;
}
