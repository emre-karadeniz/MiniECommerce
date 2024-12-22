using FluentValidation;

namespace MiniECommerce.Application.Orders.Commands.AdminCancelOrder
{
    public class AdminCancelOrderCommandValidator : AbstractValidator<AdminCancelOrderCommand>
    {
        public AdminCancelOrderCommandValidator()
        {
            RuleFor(x => x.OrderId).NotEmpty();
        }
    }
}
