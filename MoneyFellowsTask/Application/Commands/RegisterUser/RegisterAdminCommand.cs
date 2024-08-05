using Application.DTOs.Registration;
using MediatR;

namespace Application.Commands.RegisterUser
{
    public record RegisterAdminCommand(RegisterationUser User) : IRequest<RegistrationResult>;
}
