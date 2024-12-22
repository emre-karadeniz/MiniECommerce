using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Application.Core.Constants;
using MiniECommerce.Domain.Core;
using MiniECommerce.Domain.Orders;

namespace MiniECommerce.Application.Orders.Commands.AdminCancelOrder
{
    public class AdminCancelOrderCommandHandler : ICommandHandler<AdminCancelOrderCommand, Result<NoContentDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AdminCancelOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<NoContentDto>> Handle(AdminCancelOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdAsync(request.OrderId, cancellationToken);
            if (order == null)
            {
                return Result<NoContentDto>.BadRequest(Messages.Common.NotFound);
            }
            order.Status = OrderStatus.Cancelled;
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<NoContentDto>.Success("Order Canceled.");
        }
    }
}
