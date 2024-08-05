using Core.DTOs.Registration;
using MediatR;

namespace Application.Commands.Login
{
    public record LoginCommand(ApplicationUser User) : IRequest<string>;

}
