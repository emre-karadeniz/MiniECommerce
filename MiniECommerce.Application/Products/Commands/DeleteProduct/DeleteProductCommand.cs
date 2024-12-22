using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Domain.Core;

namespace MiniECommerce.Application.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand(Guid ProductId) : ICommand<Result<NoContentDto>>;

}
