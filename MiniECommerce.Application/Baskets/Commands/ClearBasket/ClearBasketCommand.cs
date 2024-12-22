using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Application.Baskets.Commands.ClearBasket
{
    public record ClearBasketCommand() : ICommand<Result<NoContentDto>>;
}
