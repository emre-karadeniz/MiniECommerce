using Microsoft.AspNetCore.Http;
using MiniECommerce.Application.Abstractions.Authentication.Jwt;
using System.Security.Claims;

namespace MiniECommerce.Infrastructure.Authentication.Jwt
{
    internal class UserIdentifierProvider : IUserIdentifierProvider
    {
        public UserIdentifierProvider(IHttpContextAccessor httpContextAccessor)
        {
            string userIdClaim = httpContextAccessor
                .HttpContext?
                .User
                .Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(userIdClaim))
            {
                throw new ArgumentException("The user identifier claim is required.", nameof(httpContextAccessor));
            }

            UserId = Guid.Parse(userIdClaim);
        }

        public Guid UserId { get; }
    }
}
