namespace MiniECommerce.Contracts.Products
{
    public record UpdateProductStockRequest(Guid ProductId, int Stock);
}
