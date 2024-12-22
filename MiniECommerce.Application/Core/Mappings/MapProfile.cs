using AutoMapper;
using MiniECommerce.Application.Authentication.Commands.Login;
using MiniECommerce.Application.Authentication.Commands.Register;
using MiniECommerce.Application.Baskets.Commands.CreateBasketItem;
using MiniECommerce.Application.Baskets.Commands.UpdateBasketItemQuantity;
using MiniECommerce.Application.Products.Commands.CreateProduct;
using MiniECommerce.Application.Products.Commands.UpdateProduct;
using MiniECommerce.Application.Products.Commands.UpdateProductStock;
using MiniECommerce.Contracts.Authentication;
using MiniECommerce.Contracts.Baskets;
using MiniECommerce.Contracts.Products;
using MiniECommerce.Domain.Products;

namespace MiniECommerce.Application.Core.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<CreateProductRequest, CreateProductCommand>();
            CreateMap<RegisterRequest, RegisterCommand>();
            CreateMap<LoginRequest, LoginCommand>();
            CreateMap<Product, ProductResponse>();
            CreateMap<UpdateProductRequest, UpdateProductCommand>();
            CreateMap<UpdateProductCommand, Product>();
            CreateMap<CreateBasketItemRequest, CreateBasketItemCommand>();
            CreateMap<UpdateBasketItemQuantityRequest, UpdateBasketItemQuantityCommand>();
            CreateMap<UpdateProductStockRequest, UpdateProductStockCommand>();
        }
    }
}
