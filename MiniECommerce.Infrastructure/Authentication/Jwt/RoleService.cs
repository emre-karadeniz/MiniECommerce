using MiniECommerce.Application.Abstractions.Authentication.Jwt;
using MiniECommerce.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Infrastructure.Authentication.Jwt
{
    public class RoleService : IRoleService
    {
        private readonly IUserRepository _userRepository;

        public RoleService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<string>> GetRolesAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return (await _userRepository.GetRolesAsync(userId, cancellationToken)).Select(x =>x.Name).ToList();
        }
    }
}
