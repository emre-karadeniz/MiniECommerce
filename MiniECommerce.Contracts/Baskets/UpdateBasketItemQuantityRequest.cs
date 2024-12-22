namespace MiniECommerce.Contracts.Baskets
{
    public record UpdateBasketItemQuantityRequest(Guid BasketItemId, bool IsIncrease);
}
