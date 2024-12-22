using MiniECommerce.Domain.Baskets;
using MiniECommerce.Domain.Core;
using MiniECommerce.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Domain.Orders
{
    public class Order : Entity, IAuditableEntity
    {
        public Guid Id { get; set; }
        public Guid BasketId { get; set; }
        public Basket Basket { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedDate { get; init; }
        public DateTime? UpdatedDate { get; init; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
