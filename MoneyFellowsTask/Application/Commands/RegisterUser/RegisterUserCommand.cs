using Application.DTOs.Registration;
using MediatR;

namespace Application.Commands.RegisterUser
{
    public record RegisterUserCommand(RegisterationUser User) : IRequest<RegistrationResult>;
}
