using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MiniECommerce.Application.Abstractions.Authentication.Jwt;
using MiniECommerce.Contracts.Authentication;
using MiniECommerce.Domain.Users;
using MiniECommerce.Infrastructure.Authentication.Jwt.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MiniECommerce.Infrastructure.Authentication.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        private readonly IRoleService _roleService;
        public IConfiguration Configuration { get; }
        private DateTime _accessTokenExpiration;
        private TokenOptions _tokenOptions;

        public JwtHelper(IConfiguration configuration, IRoleService roleService)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection(key: "TokenOptions").Get<TokenOptions>();
            _roleService = roleService;
        }
        public async Task<TokenResponse> CreateToken(User user, CancellationToken cancellationToken = default)
        {
            List<string> roles = await _roleService.GetRolesAsync(user.Id, cancellationToken);

            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
            var signingCredentials = new SigningCredentials(securityKey, algorithm: SecurityAlgorithms.HmacSha256Signature);
            var jwt = CreateJwtSecurityToken(_tokenOptions, signingCredentials, user, roles);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new TokenResponse { AccessToken = token, AccessTokenExpiration = _accessTokenExpiration };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, SigningCredentials signingCredentials, User user, List<string> roles)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
            claims: SetClaims(user, roles),
                signingCredentials: signingCredentials
                );
            return jwt;
        }

        public IEnumerable<Claim> SetClaims(User user, List<string> roles)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            return claims;
        }
    }
}
