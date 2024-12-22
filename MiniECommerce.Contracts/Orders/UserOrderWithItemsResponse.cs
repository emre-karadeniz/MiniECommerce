namespace MiniECommerce.Contracts.Orders
{
    public class UserOrderWithItemsResponse
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<OrderItemResponse> OrderItems { get; set; }
    }
}
