namespace MiniECommerce.Contracts.Orders
{
    public class UserOrderResponse
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
