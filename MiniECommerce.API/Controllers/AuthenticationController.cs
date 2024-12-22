using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Application.Authentication.Commands.Login;
using MiniECommerce.Application.Authentication.Commands.Register;
using MiniECommerce.Contracts.Authentication;

namespace MiniECommerce.API.Controllers
{
    public class AuthenticationController : CustomBaseController
    {
        public AuthenticationController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            return CreateActionResult(await _mediator.Send(_mapper.Map<RegisterCommand>(registerRequest)));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            return CreateActionResult(await _mediator.Send(_mapper.Map<LoginCommand>(loginRequest)));
        }
    }
}
