using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Application.Orders.Commands.AdminApproveOrder
{
    public class AdminApproveOrderCommandValidator:AbstractValidator<AdminApproveOrderCommand>
    {
        public AdminApproveOrderCommandValidator()
        {
            RuleFor(x=>x.OrderId).NotEmpty();
        }
    }
}
