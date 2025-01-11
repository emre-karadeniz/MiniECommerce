namespace MiniECommerce.Application.Abstractions.Authentication.Jwt
{
    public interface IUserIdentifierProvider
    {
        Guid UserId { get; }
        List<string> Roles { get; }
    }
}
