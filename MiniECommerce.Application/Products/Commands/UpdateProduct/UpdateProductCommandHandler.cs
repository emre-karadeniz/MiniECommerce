using AutoMapper;
using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Application.Core.Constants;
using MiniECommerce.Domain.Core;
using MiniECommerce.Domain.Products;

namespace MiniECommerce.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, Result<NoContentDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<NoContentDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
            if (product == null)
            {
                return Result<NoContentDto>.NotFound(Messages.Common.NotFound);
            }

            product = _mapper.Map(request, product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<NoContentDto>.Success(Messages.Common.Update);
        }
    }
}
