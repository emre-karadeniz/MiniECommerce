using FluentValidation;
using MiniECommerce.Application.Orders.Commands.CancelOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {

            RuleFor(x => x.ProductId).NotEmpty();
        }
    }
}
