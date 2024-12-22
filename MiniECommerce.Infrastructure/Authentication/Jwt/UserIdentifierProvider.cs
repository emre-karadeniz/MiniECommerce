using Microsoft.AspNetCore.Http;
using MiniECommerce.Application.Abstractions.Authentication.Jwt;
using MiniECommerce.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Infrastructure.Authentication.Jwt
{
    internal class UserIdentifierProvider : IUserIdentifierProvider
    {
        public UserIdentifierProvider(IHttpContextAccessor httpContextAccessor)
        {
            string? userIdClaim = httpContextAccessor
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
