using MiniECommerce.Domain.Baskets;
using MiniECommerce.Domain.Core;
using MiniECommerce.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Domain.Users
{
    public class User : Entity, IAuditableEntity
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] PWSalt { get; set; }
        public byte[] PWHash { get; set; }
        public DateTime CreatedDate { get; init; }
        public DateTime? UpdatedDate { get; init; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Basket> Baskets { get; set; }
    }
}
