using MiniECommerce.Domain.Core;
using MiniECommerce.Domain.Products;

namespace MiniECommerce.Domain.Orders
{
    public class OrderItem : Entity, IAuditableEntity
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; init; }
        public DateTime? UpdatedDate { get; init; }
    }
}
