using MiniECommerce.Application.Abstractions.Authentication.Jwt;
using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Application.Core.Constants;
using MiniECommerce.Domain.Core;
using MiniECommerce.Domain.Orders;
using MiniECommerce.Domain.Products;

namespace MiniECommerce.Application.Orders.Commands.CancelOrder
{
    public class CancelOrderCommandHandler : ICommandHandler<CancelOrderCommand, Result<NoContentDto>>
    {
        private readonly IUserIdentifierProvider _userIdentifierProvider;
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IOrderItemRepository _orderItemRepository;

        public CancelOrderCommandHandler(IUserIdentifierProvider userIdentifierProvider, IOrderRepository orderRepository, IUnitOfWork unitOfWork, IProductRepository productRepository, IOrderItemRepository orderItemRepository)
        {
            _userIdentifierProvider = userIdentifierProvider;
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _orderItemRepository = orderItemRepository;
        }

        public async Task<Result<NoContentDto>> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdAndUserIdAsync(request.OrderId, _userIdentifierProvider.UserId, cancellationToken);
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

            return Result<NoContentDto>.Success("Order Cancelled.");
        }
    }
}
