using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Contracts.Authentication;
using MiniECommerce.Domain.Core;
using MiniECommerce.Domain.Users;

namespace MiniECommerce.Application.Authentication.Commands.Register
{
    public record RegisterCommand(string UserName, string FirstName, string LastName, string Password, RoleEnum RoleId) : ICommand<Result<NoContentDto>>;
}
