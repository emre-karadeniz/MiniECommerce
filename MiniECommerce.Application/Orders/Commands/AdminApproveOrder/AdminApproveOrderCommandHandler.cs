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

namespace MiniECommerce.Application.Orders.Commands.AdminApproveOrder
{
    public class AdminApproveOrderCommandHandler : ICommandHandler<AdminApproveOrderCommand, Result<NoContentDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AdminApproveOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<NoContentDto>> Handle(AdminApproveOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdAsync(request.OrderId, cancellationToken);
            if (order == null)
            {
                return Result<NoContentDto>.BadRequest("Sipariş bulunamadı");
            }
            order.Status = OrderStatus.Approved;
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<NoContentDto>.Success("");
        }
    }
}
