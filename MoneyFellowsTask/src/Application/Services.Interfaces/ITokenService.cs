using Core.DTOs.Registration;

namespace Application.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(ApplicationUser user, IEnumerable<string> roles);
    }
}
