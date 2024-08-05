using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        bool IsUsernameTaken(string user);
        bool IsEmailTaken(string email);
        Task<User> ValidateUserAsync(string Username, string Password);
    }
}
