namespace MiniECommerce.Contracts.Products
{
    public record UpdateProductRequest(Guid Id, string Name, decimal Price, int Stock);
}
