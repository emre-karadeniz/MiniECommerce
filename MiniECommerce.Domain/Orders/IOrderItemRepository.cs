namespace MiniECommerce.Domain.Orders
{
    public interface IOrderItemRepository
    {
        Task AddRangeAsync(IEnumerable<OrderItem> entities, CancellationToken cancellationToken = default);
        Task<List<OrderItem>> GetProductIdsByOrderId(Guid orderId, CancellationToken cancellationToken = default);
    }
}
