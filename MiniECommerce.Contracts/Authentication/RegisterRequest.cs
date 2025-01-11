namespace MiniECommerce.Contracts.Authentication
{
    public record RegisterRequest(string UserName, string FirstName, string LastName, string Password, int RoleId);
}
