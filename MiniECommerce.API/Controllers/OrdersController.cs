using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Application.Orders.Commands.AdminApproveOrder;
using MiniECommerce.Application.Orders.Commands.AdminCancelOrder;
using MiniECommerce.Application.Orders.Commands.CancelOrder;
using MiniECommerce.Application.Orders.Commands.CreateOrder;
using MiniECommerce.Application.Orders.Queries.GetAdminOrders;
using MiniECommerce.Application.Orders.Queries.GetAdminOrderWithItems;
using MiniECommerce.Application.Orders.Queries.GetUserOrders;
using MiniECommerce.Application.Orders.Queries.GetUserOrderWithItems;
using System.ComponentModel.DataAnnotations;

namespace MiniECommerce.API.Controllers
{
    public class OrdersController : CustomBaseController
    {
        public OrdersController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        [HttpPost("[action]")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CreateOrder()
        {
            var response = await _mediator.Send(new CreateOrderCommand());
            return CreateActionResult(response);
        }

        [HttpPatch("[action]")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CancelOrder(Guid orderId)
        {
            var response = await _mediator.Send(new CancelOrderCommand(orderId));
            return CreateActionResult(response);
        }

        [HttpPatch("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminCancelOrder(Guid orderId)
        {
            var response = await _mediator.Send(new AdminCancelOrderCommand(orderId));
            return CreateActionResult(response);
        }

        [HttpPatch("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminApproveOrder(Guid orderId)
        {
            var response = await _mediator.Send(new AdminApproveOrderCommand(orderId));
            return CreateActionResult(response);
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAdminOrders()
        {
            var response = await _mediator.Send(new GetAdminOrdersQuery());
            return CreateActionResult(response);
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAdminOrderWithItems(Guid orderId)
        {
            var response = await _mediator.Send(new GetAdminOrderWithItemsQuery(orderId));
            return CreateActionResult(response);
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetUserOrders()
        {
            var response = await _mediator.Send(new GetUserOrdersQuery());
            return CreateActionResult(response);
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetUserOrderWithItems([Required] Guid orderId)
        {
            var response = await _mediator.Send(new GetUserOrderWithItemsQuery(orderId));
            return CreateActionResult(response);
        }
    }
}
