using MiniECommerce.Application.Abstractions.Authentication.Jwt;
using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Domain.Baskets;
using MiniECommerce.Domain.Core;
using MiniECommerce.Domain.Orders;
using MiniECommerce.Domain.Products;
using MiniECommerce.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, Result<NoContentDto>>
    {
        private readonly IUserIdentifierProvider _userIdentifierProvider;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasketRepository _basketRepository;
        private readonly IProductRepository _productRepository;

        public CreateOrderCommandHandler(IUserIdentifierProvider userIdentifierProvider, IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IUnitOfWork unitOfWork, IBasketRepository basketRepository, IProductRepository productRepository)
        {
            _userIdentifierProvider = userIdentifierProvider;
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _unitOfWork = unitOfWork;
            _basketRepository = basketRepository;
            _productRepository = productRepository;
        }

        public async Task<Result<NoContentDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetActiveBasketWithBasketItemsAsync(_userIdentifierProvider.UserId,cancellationToken);

            if (basket == null)
            {
                return Result<NoContentDto>.BadRequest("");
            }

            if (basket.BasketItems.Count == 0)
            {
                return Result<NoContentDto>.BadRequest("");
            }


            var productIds = basket.BasketItems.Select(bi => bi.ProductId).ToList();
            var products = await _productRepository.GetProductsByIdsAsync(productIds);

            var productDictionary = products.ToDictionary(p => p.Id);

            foreach (var basketItem in basket.BasketItems)
            {
                if (!productDictionary.TryGetValue(basketItem.ProductId, out var product))
                {
                    return Result<NoContentDto>.BadRequest("Ürün bulunamadı. İşlem iptal edildi.");
                }

                if (product.Stock < basketItem.Quantity)
                {
                    return Result<NoContentDto>.BadRequest($"{product.Name} stok yetersiz. İşlem iptal edildi.");
                }
                //ürünlerin stoklarının düşmesi
                product.Stock-=basketItem.Quantity;
            }

            var totalPrice = basket.BasketItems.Sum(x=>x.Quantity * x.Product.Price);

            var order = new Order()
            {
                Id = Guid.NewGuid(),
                UserId = _userIdentifierProvider.UserId,
                BasketId = basket.Id,
                Status = OrderStatus.Created,
                TotalPrice = totalPrice
            };

            await _orderRepository.AddAsync(order);

            var orderItems = basket.BasketItems.Select(basketItem => new OrderItem
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                ProductId = basketItem.ProductId,
                ProductName = basketItem.Product.Name,
                ProductPrice = basketItem.Product.Price,
                Quantity = basketItem.Quantity
            }).ToList();

            await _orderItemRepository.AddRangeAsync(orderItems);

            basket.Status=BasketStatus.Completed;

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result<NoContentDto>.Success("");
        }
    }
}
