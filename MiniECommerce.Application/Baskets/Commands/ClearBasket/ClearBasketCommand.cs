using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Domain.Core;

namespace MiniECommerce.Application.Baskets.Commands.ClearBasket
{
    public record ClearBasketCommand() : ICommand<Result<NoContentDto>>;
}
