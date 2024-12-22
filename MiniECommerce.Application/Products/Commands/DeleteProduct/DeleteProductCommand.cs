﻿using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Application.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand(Guid ProductId) : ICommand<Result<NoContentDto>>;

}