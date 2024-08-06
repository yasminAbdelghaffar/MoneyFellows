using Core.DTOs.Registration;
using Core.Entities;
using Core.Enums;
using Core.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNet.Identity;

namespace Application.Commands.RegisterUser
{
    public class RegisterAdminCommandHandler : IRequestHandler<RegisterUserCommand, RegistrationResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterAdminCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task<RegistrationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = MapAdminEntity(request.User);
            await _userRepository.AddAsync(user);
            return new RegistrationResult { Success = true, UserId = user.Id, Message = "Registration successful." };

        }

        #region Helper Methods
        private User MapAdminEntity(RegisterationUser request)
        {
            var hashedPassword = _passwordHasher.HashPassword(request.Password);
            return new User
            {
                Username = request.Username,
                Email = request.Email,
                Password = hashedPassword,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone,
                Type = UserType.Admin,
            };
        }
        #endregion
    }
}
