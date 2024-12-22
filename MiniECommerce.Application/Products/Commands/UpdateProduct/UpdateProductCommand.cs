using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Domain.Core;

namespace MiniECommerce.Application.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name, decimal Price, int Stock) : ICommand<Result<NoContentDto>>;
}
