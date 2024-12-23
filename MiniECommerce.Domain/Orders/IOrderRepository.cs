﻿namespace MiniECommerce.Domain.Orders
{
    public interface IOrderRepository
    {
        Task AddAsync(Order entity, CancellationToken cancellationToken = default);
        Task<Order> GetOrderByIdAndUserIdAsync(Guid id, Guid userId, CancellationToken cancellationToken = default);
        Task<Order> GetOrderByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
