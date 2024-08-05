using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public bool IsEmailTaken(string email)
        {
            throw new NotImplementedException();
        }

        public bool IsUsernameTaken(string user)
        {
            throw new NotImplementedException();
        }

        public Task<User> ValidateUserAsync(string Username, string Password)
        {
            throw new NotImplementedException();
        }
    }
}
