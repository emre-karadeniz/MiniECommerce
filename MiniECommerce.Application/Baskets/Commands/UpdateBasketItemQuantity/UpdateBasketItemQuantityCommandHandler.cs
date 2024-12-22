using MiniECommerce.Application.Abstractions.Authentication.Jwt;
using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Application.Core.Constants;
using MiniECommerce.Domain.Baskets;
using MiniECommerce.Domain.Core;

namespace MiniECommerce.Application.Baskets.Commands.UpdateBasketItemQuantity
{
    public class UpdateBasketItemQuantityCommandHandler : ICommandHandler<UpdateBasketItemQuantityCommand, Result<NoContentDto>>
    {
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserIdentifierProvider _userIdentifierProvider;
        public UpdateBasketItemQuantityCommandHandler(IBasketItemRepository basketItemRepository, IUnitOfWork unitOfWork, IUserIdentifierProvider userIdentifierProvider)
        {
            _basketItemRepository = basketItemRepository;
            _unitOfWork = unitOfWork;
            _userIdentifierProvider = userIdentifierProvider;
        }

        public async Task<Result<NoContentDto>> Handle(UpdateBasketItemQuantityCommand request, CancellationToken cancellationToken)
        {
            var basketItem = await _basketItemRepository.GetAsync(x => x.Id == request.BasketItemId && x.Basket.Status == BasketStatus.Active && x.Basket.UserId == _userIdentifierProvider.UserId, [basketItem => basketItem.Basket], cancellationToken);

            if (basketItem == null)
            {
                return Result<NoContentDto>.NotFound("sepet böyle bir ürün bulunamadı");
            }

            basketItem.Quantity = request.IsIncrease ? basketItem.Quantity + 1 : basketItem.Quantity - 1;

            if (basketItem.Quantity <= 0)
            {
                _basketItemRepository.Delete(basketItem);
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<NoContentDto>.Success(Messages.Common.Success);
        }
    }
}
