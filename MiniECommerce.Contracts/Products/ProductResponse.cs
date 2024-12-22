using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Contracts.Products
{
    public record ProductResponse(Guid Id,string Name,decimal Price,int Stock);
}
