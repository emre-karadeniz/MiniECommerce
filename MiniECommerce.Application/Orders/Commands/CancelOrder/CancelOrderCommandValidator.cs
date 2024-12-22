﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Application.Orders.Commands.CancelOrder
{
    public class CancelOrderCommandValidator:AbstractValidator<CancelOrderCommand>
    {
        public CancelOrderCommandValidator()
        {

            RuleFor(x=>x.OrderId).NotEmpty();
        }
    }
}
