using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
    }
}
