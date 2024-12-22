using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Contracts.Baskets
{
    public record CreateBasketItemRequest(Guid ProductId, int Quantity);
}
