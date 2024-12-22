using MiniECommerce.Domain.Core;
using MiniECommerce.Domain.Users;

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
