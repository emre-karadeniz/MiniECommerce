using MiniECommerce.Application.Abstractions.Authentication.Jwt;
using MiniECommerce.Domain.Users;

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
            return (await _userRepository.GetRolesAsync(userId, cancellationToken)).Select(x => x.Name).ToList();
        }
    }
}
