using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Contracts.Products;
using MiniECommerce.Domain.Core;

namespace MiniECommerce.Application.Products.Queries.GetProducts
{
    public record GetProductsQuery() : IQuery<Result<List<ProductResponse>>>;
}
