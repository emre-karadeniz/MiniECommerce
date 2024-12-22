using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Domain.Core;

namespace MiniECommerce.Application.Orders.Commands.AdminCancelOrder
{
    public record AdminCancelOrderCommand(Guid OrderId) : ICommand<Result<NoContentDto>>;
}
