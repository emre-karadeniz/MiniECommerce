using AutoMapper;
using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Application.Core.Constants;
using MiniECommerce.Contracts.Products;
using MiniECommerce.Domain.Core;
using MiniECommerce.Domain.Products;

namespace MiniECommerce.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, Result<ProductResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Result<ProductResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
            if (products == null)
            {
                return Result<ProductResponse>.NotFound(Messages.Common.NotFound);
            }
            var response = _mapper.Map<ProductResponse>(products);
            return Result<ProductResponse>.Success(Messages.Common.Success, response);
        }
    }
}
