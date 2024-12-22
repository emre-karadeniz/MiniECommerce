using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Application.Baskets.Commands.UpdateBasketItemQuantity
{
    public class UpdateBasketItemQuantityCommandValidator : AbstractValidator<UpdateBasketItemQuantityCommand>
    {
        public UpdateBasketItemQuantityCommandValidator()
        {
            RuleFor(x => x.BasketItemId).NotEmpty();
        }
    }
}
