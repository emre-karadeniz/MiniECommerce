using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Domain.Core;

namespace MiniECommerce.Application.Orders.Commands.AdminApproveOrder
{
    public record AdminApproveOrderCommand(Guid OrderId) : ICommand<Result<NoContentDto>>;
}
