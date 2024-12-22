using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Application.Core.Constants;
using MiniECommerce.Contracts.Products;
using MiniECommerce.Domain.Core;
using MiniECommerce.Domain.Products;

namespace MiniECommerce.Application.Products.Queries.GetProducts
{
    public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, Result<List<ProductResponse>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<ProductResponse>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAll().OrderByDescending(x => x.CreatedDate).ToListAsync(cancellationToken);
            var response = _mapper.Map<List<ProductResponse>>(products);
            return Result<List<ProductResponse>>.Success(Messages.Common.Success, response);
        }
    }
}
