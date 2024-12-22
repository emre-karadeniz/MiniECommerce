using MiniECommerce.Application.Abstractions.Data;
using MiniECommerce.Application.Abstractions.Encryption;
using MiniECommerce.Application.Abstractions.Messaging;
using MiniECommerce.Application.Core.Constants;
using MiniECommerce.Domain.Core;
using MiniECommerce.Domain.Users;

namespace MiniECommerce.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : ICommandHandler<RegisterCommand, Result<NoContentDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHashingHelper _hashingHelper;

        public RegisterCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IHashingHelper hashingHelper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _hashingHelper = hashingHelper;
        }

        public async Task<Result<NoContentDto>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.IsUserNameUniqueAsync(request.UserName))
            {
                return Result<NoContentDto>.BadRequest(Messages.Login.RegisterFailed);
            }

            var user = new User();
            user.Id = Guid.NewGuid();
            user.UserName = request.UserName;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;

            byte[] pwSalt;
            byte[] pwHash;
            _hashingHelper.CreatePasswordHash(request.Password, out pwHash, out pwSalt);

            user.PWSalt = pwSalt;
            user.PWHash = pwHash;

            //IsAdmin eğer true ise Admin'dir, false ise User'dır.
            //Bu kaydetme işlemi için ekstra uğraşmamak için böyle yaptım.
            //Yoksa 2 adet kaydet lazım hem kullanıcı için hemde adminin herkesi kaydedebilmesi için.
            await _userRepository.AddUserRoleAsync(user.Id, request.IsAdmin ? 1 : 2, cancellationToken);

            await _userRepository.AddAsync(user, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result<NoContentDto>.Created(Messages.Common.Add);
        }
    }
}
