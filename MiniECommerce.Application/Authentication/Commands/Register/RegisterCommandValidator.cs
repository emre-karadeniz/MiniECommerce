using FluentValidation;

namespace MiniECommerce.Application.Authentication.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().MinimumLength(3);
            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3);
            RuleFor(x => x.LastName).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(3);
        }
    }
}
