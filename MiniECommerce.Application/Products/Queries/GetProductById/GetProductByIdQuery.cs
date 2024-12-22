using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Contracts.Products;
using MiniECommerce.Domain.Core;

namespace MiniECommerce.Application.Products.Queries.GetProductById
{
    public record GetProductByIdQuery(Guid Id) : IQuery<Result<ProductResponse>>;
}
