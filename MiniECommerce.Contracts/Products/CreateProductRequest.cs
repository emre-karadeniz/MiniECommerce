﻿namespace MiniECommerce.Contracts.Products
{
    public record CreateProductRequest(string Name, decimal Price, int Stock);
}
