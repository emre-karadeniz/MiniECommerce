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

            var roles = httpContextAccessor
    .HttpContext?
    .User
    .Claims
    .Where(x => x.Type == ClaimTypes.Role)
    .Select(x => x.Value)
    .ToList();

            if (string.IsNullOrWhiteSpace(userIdClaim))
            {
                throw new ArgumentException("The user identifier claim is required.", nameof(httpContextAccessor));
            }

            UserId = Guid.Parse(userIdClaim);
            Roles = roles;
        }

        public Guid UserId { get; }
        public List<string> Roles { get; set; }
    }
}
