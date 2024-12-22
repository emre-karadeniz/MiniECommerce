using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Domain.Products;
using MiniECommerce.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return await GetAsync(x => x.UserName == userName, null, cancellationToken);
        }

        public async Task<List<Role>> GetRolesAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            List<Role> roles = await _appDbContext.Set<UserRole>()
                .Include(x => x.Role)
                .Where(x => x.UserId == userId)
                .Select(x => x.Role)
                .AsNoTracking()
                .ToListAsync();
            return roles;
        }

        public async Task<bool> IsUserNameUniqueAsync(string userName, CancellationToken cancellationToken = default)
        {
            return await AnyAsync(x => x.UserName == userName, cancellationToken);
        }
    }
}
