using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Domain.Core;

namespace MiniECommerce.Application.Authentication.Commands.Register
{
    public record RegisterCommand(string UserName, string FirstName, string LastName, string Password, bool IsAdmin) : ICommand<Result<NoContentDto>>;
}
