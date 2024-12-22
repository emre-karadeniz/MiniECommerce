using MiniECommerce.Application.Abstractions.Authentication.Jwt;
using MiniECommerce.Application.Abstractions.Encryption;
using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Application.Core.Constants;
using MiniECommerce.Contracts.Authentication;
using MiniECommerce.Domain.Core;
using MiniECommerce.Domain.Users;

namespace MiniECommerce.Application.Authentication.Commands.Login
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, Result<TokenResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IHashingHelper _hashingHelper;

        public LoginCommandHandler(IUserRepository userRepository, ITokenHelper tokenHelper, IHashingHelper hashingHelper)
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
            _hashingHelper = hashingHelper;
        }

        public async Task<Result<TokenResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUserNameAsync(request.UserName);

            if (user == null)
            {
                return Result<TokenResponse>.BadRequest(Messages.Login.LoginFailed);
            }

            if (!_hashingHelper.VerifyPasswordHash(request.Password, user.PWHash, user.PWSalt))
            {
                return Result<TokenResponse>.BadRequest(Messages.Login.LoginFailed);
            }

            var tokenResponse = await _tokenHelper.CreateToken(user, cancellationToken);

            return Result<TokenResponse>.Success(Messages.Common.Success, tokenResponse);
        }
    }
}
