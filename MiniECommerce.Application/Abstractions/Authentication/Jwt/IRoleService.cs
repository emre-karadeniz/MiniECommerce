using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Application.Abstractions.Authentication.Jwt
{
    public interface IRoleService
    {
        Task<List<string>> GetRolesAsync(Guid userId, CancellationToken cancellationToken = default);
    }
}
