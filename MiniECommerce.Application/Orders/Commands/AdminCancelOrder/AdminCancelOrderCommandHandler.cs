using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Application.Core.Constants;
using MiniECommerce.Domain.Core;
using MiniECommerce.Domain.Orders;
using MiniECommerce.Domain.Products;

namespace MiniECommerce.Application.Orders.Commands.AdminCancelOrder
{
    public class AdminCancelOrderCommandHandler : ICommandHandler<AdminCancelOrderCommand, Result<NoContentDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IOrderItemRepository _orderItemRepository;

        public AdminCancelOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IOrderItemRepository orderItemRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _orderItemRepository = orderItemRepository;
            _productRepository = productRepository;
        }
        public async Task<Result<NoContentDto>> Handle(AdminCancelOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdAsync(request.OrderId, cancellationToken);
            if (order == null)
            {
                return Result<NoContentDto>.BadRequest(Messages.Common.NotFound);
            }

            order.Status = OrderStatus.Cancelled;

            var orderItems = await _orderItemRepository.GetProductIdsByOrderId(order.Id, cancellationToken);
            foreach (var orderItem in orderItems)
            {
                var product = await _productRepository.GetByIdAsync(orderItem.ProductId, cancellationToken);
                if (product != null)
                {
                    product.Stock += orderItem.Quantity;
                }
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<NoContentDto>.Success("Order Canceled.");
        }
    }
}
