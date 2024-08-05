using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
        }

        public bool IsEmailTaken(string email)
        {
            return _context.User.Any(u => u.Email == email);
        }

        public bool IsUsernameTaken(string user)
        {
            return _context.User.Any(u => u.Username == user);
        }

        public async Task<User> ValidateUserAsync(string Username, string Password)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Username == Username && u.Password == Password);
        }
    }
}
