using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Domain.Core;

namespace MiniECommerce.Application.Orders.Commands.CancelOrder
{
    public record CancelOrderCommand(Guid OrderId) : ICommand<Result<NoContentDto>>;
}
