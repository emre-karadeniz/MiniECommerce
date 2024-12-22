using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Domain.Baskets;
using MiniECommerce.Domain.Orders;
using MiniECommerce.Domain.Products;
using MiniECommerce.Domain.Users;
using MiniECommerce.Persistence.Repositories;

namespace MiniECommerce.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("MiniECommerceDb");
            services.AddDbContext<AppDbContext>
                (options => options.UseSqlServer(connectionString));

            services.AddScoped<IAppDbContext>(serviceProvider =>
                serviceProvider.GetRequiredService<AppDbContext>());

            services.AddScoped<IUnitOfWork>(serviceProvider =>
                serviceProvider.GetRequiredService<AppDbContext>());

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IBasketItemRepository, BasketItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();

            return services;
        }
    }
}
