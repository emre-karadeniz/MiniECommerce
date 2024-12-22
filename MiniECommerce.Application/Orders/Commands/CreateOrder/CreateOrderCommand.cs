using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Domain.Core;

namespace MiniECommerce.Application.Orders.Commands.CreateOrder
{
    public record CreateOrderCommand() : ICommand<Result<NoContentDto>>;
}
