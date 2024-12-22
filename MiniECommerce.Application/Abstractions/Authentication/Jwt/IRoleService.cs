namespace MiniECommerce.Application.Abstractions.Authentication.Jwt
{
    public interface IRoleService
    {
        Task<List<string>> GetRolesAsync(Guid userId, CancellationToken cancellationToken = default);
    }
}
