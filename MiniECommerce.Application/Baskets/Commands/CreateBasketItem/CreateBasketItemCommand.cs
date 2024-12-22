using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Domain.Core;

namespace MiniECommerce.Application.Baskets.Commands.CreateBasketItem
{
    public record CreateBasketItemCommand(Guid ProductId, int Quantity) : ICommand<Result<NoContentDto>>;
}
