using MiniECommerce.Domain.Core;
using MiniECommerce.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Domain.Baskets
{
    public class Basket : Entity, IAuditableEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public BasketStatus Status { get; set; }      
        public DateTime CreatedDate { get; init; }
        public DateTime? UpdatedDate { get; init; }

        public ICollection<BasketItem> BasketItems { get; set; } = [];
    }
}
