using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniECommerce.Application.Abstractions.Authentication.Jwt;
using MiniECommerce.Infrastructure.Authentication.Jwt;
using MiniECommerce.Infrastructure.Authentication.Jwt.Settings;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using MiniECommerce.Domain.Core;
using System.Text.Json;
using MiniECommerce.Application.Abstractions.Encryption;
using MiniECommerce.Infrastructure.Encryption;

namespace MiniECommerce.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(tokenOptions.SecurityKey)),

                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnChallenge = context =>
                        {
                            context.HandleResponse();
                            context.Response.StatusCode = 401;
                            context.Response.ContentType = "application/json";
                            var errorMessage = new List<string> { "A valid token was not provided. Please log in." };
                            var json = JsonSerializer.Serialize(new Result<NoContentDto> { Mesaj = errorMessage });
                            return context.Response.WriteAsync(json);
                        },
                        OnForbidden = context =>
                        {

                            context.Response.StatusCode = 403;
                            context.Response.ContentType = "application/json";
                            var errorMessage = new List<string> { "Access denied: You do not have the required permissions to perform this action." };
                            var json = JsonSerializer.Serialize(new Result<NoContentDto> { Mesaj = errorMessage });
                            return context.Response.WriteAsync(json);
                        }
                    };
                });

            services.AddScoped<ITokenHelper, JwtHelper>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserIdentifierProvider, UserIdentifierProvider>();
            services.AddScoped<IHashingHelper,HashingHelper>();

            return services;
        }
    }
}
