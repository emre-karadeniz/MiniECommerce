using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Contracts.Products;
using MiniECommerce.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Application.Products.Queries.GetProductById
{
    public record GetProductByIdQuery(Guid Id):IQuery<Result<ProductResponse>>;
}
