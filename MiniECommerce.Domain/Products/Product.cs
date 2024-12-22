using MiniECommerce.Domain.Core;

namespace MiniECommerce.Domain.Products
{
    public class Product : Entity, IAuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public DateTime CreatedDate { get; init; }
        public DateTime? UpdatedDate { get; init; }
    }
}
