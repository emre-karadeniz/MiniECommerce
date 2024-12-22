using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Application.Baskets.Commands.ClearBasket;
using MiniECommerce.Application.Baskets.Commands.CreateBasketItem;
using MiniECommerce.Application.Baskets.Commands.UpdateBasketItemQuantity;
using MiniECommerce.Application.Baskets.Queries.GetBasketItems;
using MiniECommerce.Application.Products.Commands.CreateProduct;
using MiniECommerce.Contracts.Baskets;
using MiniECommerce.Contracts.Products;

namespace MiniECommerce.API.Controllers
{
    public class BasketsController : CustomBaseController
    {
        public BasketsController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        [HttpPost("[action]")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CreateBasketItem(CreateBasketItemRequest createBasketItemRequest)
        {
            var response = await _mediator.Send(_mapper.Map<CreateBasketItemCommand>(createBasketItemRequest));
            return CreateActionResult(response);
        }


        [HttpPatch("[action]")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdateBasketItemQuantity(UpdateBasketItemQuantityRequest updateBasketItemQuantityRequest)
        {
            var response = await _mediator.Send(_mapper.Map<UpdateBasketItemQuantityCommand>(updateBasketItemQuantityRequest));
            return CreateActionResult(response);
        }

        [HttpDelete("[action]")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> ClearBasket()
        {
            var response = await _mediator.Send(new ClearBasketCommand());
            return CreateActionResult(response);
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetBasketItems()
        {
            var response = await _mediator.Send(new GetBasketItemsQuery());
            return CreateActionResult(response);
        }
    }
}
