using MiniECommerce.Application.Abstractions.Authentication.Jwt;
using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Application.Core.Constants;
using MiniECommerce.Domain.Baskets;
using MiniECommerce.Domain.Core;

namespace MiniECommerce.Application.Baskets.Commands.ClearBasket
{
    public class ClearBasketCommandHandler : ICommandHandler<ClearBasketCommand, Result<NoContentDto>>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IUserIdentifierProvider _userIdentifierProvider;
        private readonly IUnitOfWork _unitOfWork;

        public ClearBasketCommandHandler(IBasketRepository basketRepository, IBasketItemRepository basketItemRepository, IUserIdentifierProvider userIdentifierProvider, IUnitOfWork unitOfWork)
        {
            _basketRepository = basketRepository;
            _basketItemRepository = basketItemRepository;
            _userIdentifierProvider = userIdentifierProvider;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<NoContentDto>> Handle(ClearBasketCommand request, CancellationToken cancellationToken)
        {
            var activeBasket = await _basketRepository.GetActiveBasketAsNoTrackingAsync(_userIdentifierProvider.UserId, cancellationToken);
            if (activeBasket == null)
            {
                return Result<NoContentDto>.BadRequest(Messages.Common.NotFound);
            }

            var basketItems = _basketItemRepository.GetAll(x => x.BasketId == activeBasket.Id);
            _basketItemRepository.DeleteRange(basketItems);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result<NoContentDto>.Success(Messages.Common.Delete);


        }
    }
}
