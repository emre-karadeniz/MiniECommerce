using FluentValidation;

namespace MiniECommerce.Application.Orders.Commands.AdminApproveOrder
{
    public class AdminApproveOrderCommandValidator : AbstractValidator<AdminApproveOrderCommand>
    {
        public AdminApproveOrderCommandValidator()
        {
            RuleFor(x => x.OrderId).NotEmpty();
        }
    }
}
