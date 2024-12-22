using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Application.Baskets.Commands.CreateBasketItem
{
    public class CreateBasketItemCommandValidator:AbstractValidator<CreateBasketItemCommand>
    {
        public CreateBasketItemCommandValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.Quantity).GreaterThan(0);
        }
    }
}
