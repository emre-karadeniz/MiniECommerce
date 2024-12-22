namespace MiniECommerce.Application.Abstractions.Authentication.Jwt
{
    public interface IUserIdentifierProvider
    {
        Guid UserId { get; }
    }
}
