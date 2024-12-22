namespace MiniECommerce.Domain.Users
{
    public interface IUserRepository
    {
        Task AddAsync(User entity, CancellationToken cancellationToken = default);
        Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<User> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default);
        Task<List<Role>> GetRolesAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<bool> IsUserNameUniqueAsync(string userName, CancellationToken cancellationToken = default);
        Task AddUserRoleAsync(Guid userId, int roleId, CancellationToken cancellationToken = default);
    }
}
