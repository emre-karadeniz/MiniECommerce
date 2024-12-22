using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Domain.Core;

namespace MiniECommerce.Application.Products.Commands.CreateProduct
{
    public record CreateProductCommand(string Name, decimal Price, int Stock) : ICommand<Result<Guid>>;
}
