using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Domain.Core;

namespace MiniECommerce.Application.Products.Commands.UpdateProductStock
{
    public record UpdateProductStockCommand(Guid ProductId, int Stock) : ICommand<Result<NoContentDto>>;
}
