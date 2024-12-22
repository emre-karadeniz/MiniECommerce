using MiniECommerce.Contracts.Authentication;
using MiniECommerce.Domain.Users;

namespace MiniECommerce.Application.Abstractions.Authentication.Jwt
{
    public interface ITokenHelper
    {
        Task<TokenResponse> CreateToken(User user, CancellationToken cancellationToken = default);
    }
}
