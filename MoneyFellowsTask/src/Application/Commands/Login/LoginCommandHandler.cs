using Application.Services.Interfaces;
using Core.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNet.Identity;

namespace Application.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHasher _passwordHasher;

        public LoginCommandHandler(IUserRepository userRepository, ITokenService tokenService, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var hashedPassword = _passwordHasher.HashPassword(request.User.Password);
            var user = await _userRepository.ValidateUserAsync(request.User.UserName, hashedPassword);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }

            var roles = new List<string> { user.Type.ToString()};
            return _tokenService.GenerateToken(request.User, roles);
        }
    }
}
