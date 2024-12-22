using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Contracts.Baskets;
using MiniECommerce.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Application.Baskets.Queries.GetBasketItems
{
    public record GetBasketItemsQuery():IQuery<Result<List<BasketItemResponse>>>;
}
