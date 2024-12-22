namespace MiniECommerce.Contracts.Orders
{
    public class AdminOrderWithItemsResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<OrderItemResponse> OrderItems { get; set; }
    }
}
