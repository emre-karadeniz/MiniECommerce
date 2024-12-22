using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Application.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name, decimal Price, int Stock) : ICommand<Result<NoContentDto>>;
}
