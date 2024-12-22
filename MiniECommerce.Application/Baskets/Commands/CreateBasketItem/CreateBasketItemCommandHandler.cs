using MiniECommerce.Application.Abstractions.Authentication.Jwt;
using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Domain.Baskets;
using MiniECommerce.Domain.Core;
using MiniECommerce.Domain.Products;

namespace MiniECommerce.Application.Baskets.Commands.CreateBasketItem
{
    public class CreateBasketItemCommandHandler : ICommandHandler<CreateBasketItemCommand, Result<NoContentDto>>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IUserIdentifierProvider _userIdentifierProvider;

        public CreateBasketItemCommandHandler(IBasketRepository basketRepository, IUnitOfWork unitOfWork, IProductRepository productRepository, IUserIdentifierProvider userIdentifierProvider, IBasketItemRepository basketItemRepository)
        {
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _userIdentifierProvider = userIdentifierProvider;
            _basketItemRepository = basketItemRepository;
        }

        public async Task<Result<NoContentDto>> Handle(CreateBasketItemCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);
            if (product == null) 
            {
                return Result<NoContentDto>.NotFound("ürün bulunamadı");
            }

            if (product.Stock<request.Quantity) 
            {
                return Result<NoContentDto>.BadRequest("yeterli stok yok. ürün eklenemedi");
            }

            var basket = await _basketRepository.GetActiveBasketAsNoTrackingAsync(_userIdentifierProvider.UserId, cancellationToken);
            if (basket == null)
            {
                basket = new Basket()
                {
                    Id = Guid.NewGuid(),
                    UserId = _userIdentifierProvider.UserId,
                    Status = BasketStatus.Active
                };

                await _basketRepository.AddAsync(basket, cancellationToken);
            }

            var basketItem = await _basketItemRepository.GetAsync(x => x.ProductId == request.ProductId && x.BasketId == basket.Id);
            if (basketItem != null)
            {
                basketItem.Quantity += request.Quantity;
            }
            else
            {
                var newBasketItem = new BasketItem()
                {
                    Id = Guid.NewGuid(),
                    BasketId = basket.Id,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity,
                };
                await _basketItemRepository.AddAsync(newBasketItem, cancellationToken);
            }


            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result<NoContentDto>.Success("Ürün sepete eklendi.");
        }
    }
}
