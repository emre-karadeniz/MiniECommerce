using FluentValidation;

namespace MiniECommerce.Application.Products.Commands.UpdateProductStock
{
    public class UpdateProductStockCommandValidator : AbstractValidator<UpdateProductStockCommand>
    {
        public UpdateProductStockCommandValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.Stock).GreaterThanOrEqualTo(0);
        }
    }
}
