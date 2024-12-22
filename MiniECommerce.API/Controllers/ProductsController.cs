using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Application.Products.Commands.CreateProduct;
using MiniECommerce.Application.Products.Commands.DeleteProduct;
using MiniECommerce.Application.Products.Commands.UpdateProduct;
using MiniECommerce.Application.Products.Commands.UpdateProductStock;
using MiniECommerce.Application.Products.Queries.GetProductById;
using MiniECommerce.Application.Products.Queries.GetProducts;
using MiniECommerce.Contracts.Products;
using System.ComponentModel.DataAnnotations;

namespace MiniECommerce.API.Controllers
{

    public class ProductsController : CustomBaseController
    {
        public ProductsController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        [HttpPost("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProduct(CreateProductRequest createProductRequest)
        {
            var response = await _mediator.Send(_mapper.Map<CreateProductCommand>(createProductRequest));
            return CreateActionResult(response);
        }

        [HttpPut("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProduct(UpdateProductRequest updateProductRequest)
        {
            var response = await _mediator.Send(_mapper.Map<UpdateProductCommand>(updateProductRequest));
            return CreateActionResult(response);
        }

        [HttpPatch("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProductStock(UpdateProductStockRequest updateProductStockRequest)
        {
            var response = await _mediator.Send(_mapper.Map<UpdateProductStockCommand>(updateProductStockRequest));
            return CreateActionResult(response);
        }

        [HttpDelete("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var response = await _mediator.Send(new DeleteProductCommand(id));
            return CreateActionResult(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProducts()
        {
            var response = await _mediator.Send(new GetProductsQuery());
            return CreateActionResult(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductById([Required] Guid id)
        {
            var response = await _mediator.Send(new GetProductByIdQuery(id));
            return CreateActionResult(response);
        }
    }
}
