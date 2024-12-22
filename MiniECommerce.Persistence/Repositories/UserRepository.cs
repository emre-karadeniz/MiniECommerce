using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Domain.Users;

namespace MiniECommerce.Persistence.Repositories
{
    internal class UserRepository : GenericRepository<User>, IUserRepository
    {

        public UserRepository(IAppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task AddUserRoleAsync(Guid userId, int roleId, CancellationToken cancellationToken = default)
        {
            var userRole = new UserRole();
            userRole.UserId = userId;
            userRole.RoleId = roleId;
            await _appDbContext.Set<UserRole>().AddAsync(userRole);
        }

        public async Task<User> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default)
        {
            return await GetAsync(u => u.UserName == userName, null, cancellationToken);
        }

        public async Task<List<Role>> GetRolesAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            List<Role> roles = await _appDbContext.Set<UserRole>()
                .Include(ur => ur.Role)
                .Where(ur => ur.UserId == userId)
                .Select(ur => ur.Role)
                .AsNoTracking()
                .ToListAsync();
            return roles;
        }

        public async Task<bool> IsUserNameUniqueAsync(string userName, CancellationToken cancellationToken = default)
        {
            return await AnyAsync(u => u.UserName == userName, cancellationToken);
        }
    }
}
