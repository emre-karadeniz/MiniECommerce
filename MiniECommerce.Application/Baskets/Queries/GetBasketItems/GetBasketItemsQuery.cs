using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Contracts.Baskets;
using MiniECommerce.Domain.Core;

namespace MiniECommerce.Application.Baskets.Queries.GetBasketItems
{
    public record GetBasketItemsQuery() : IQuery<Result<List<BasketItemResponse>>>;
}
