using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Application.Core.Constants;
using MiniECommerce.Domain.Core;
using MiniECommerce.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Application.Products.Commands.UpdateProductStock
{
    public class UpdateProductStockCommandHandler : ICommandHandler<UpdateProductStockCommand, Result<NoContentDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductStockCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<NoContentDto>> Handle(UpdateProductStockCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);
            if (product == null)
            {
                return Result<NoContentDto>.NotFound("");
            }
            product.Stock=request.Stock;
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result<NoContentDto>.Success(Messages.Common.Update);
        }
    }
}
