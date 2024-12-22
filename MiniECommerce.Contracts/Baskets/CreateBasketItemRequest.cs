namespace MiniECommerce.Contracts.Baskets
{
    public record CreateBasketItemRequest(Guid ProductId, int Quantity);
}
