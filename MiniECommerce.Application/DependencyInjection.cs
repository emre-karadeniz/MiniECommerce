using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MiniECommerce.Application.Core.Behaviors;
using System.Reflection;

namespace MiniECommerce.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

                cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));

                cfg.AddOpenBehavior(typeof(TransactionBehaviour<,>));
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
