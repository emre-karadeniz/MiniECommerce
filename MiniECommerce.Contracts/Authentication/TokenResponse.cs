namespace MiniECommerce.Contracts.Authentication
{
    public class TokenResponse
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
    }
}
