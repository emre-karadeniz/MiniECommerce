using MiniECommerce.Contracts.Authentication;
using MiniECommerce.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Application.Abstractions.Authentication.Jwt
{
    public interface ITokenHelper
    {
        Task<TokenResponse> CreateToken(User user, CancellationToken cancellationToken = default);
    }
}
