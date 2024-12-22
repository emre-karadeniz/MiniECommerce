using MiniECommerce.Application.Abstractions.Authentication.Jwt;
using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Domain.Core;
using MiniECommerce.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Application.Orders.Commands.CancelOrder
{
    public class CancelOrderCommandHandler : ICommandHandler<CancelOrderCommand, Result<NoContentDto>>
    {
        private readonly IUserIdentifierProvider _userIdentifierProvider;
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CancelOrderCommandHandler(IUserIdentifierProvider userIdentifierProvider, IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _userIdentifierProvider = userIdentifierProvider;
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<NoContentDto>> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdAndUserIdAsync(request.OrderId, _userIdentifierProvider.UserId, cancellationToken);
            if (order == null)
            {
                return Result<NoContentDto>.BadRequest("Sipariş bulunamadı");
            }
            order.Status=OrderStatus.Cancelled;
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<NoContentDto>.Success("");
        }
    }
}
