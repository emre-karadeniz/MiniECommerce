using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Contracts.Authentication;
using MiniECommerce.Domain.Core;

namespace MiniECommerce.Application.Authentication.Commands.Login
{
    public record LoginCommand(string UserName, string Password) : ICommand<Result<TokenResponse>>;
}
