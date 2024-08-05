using Core.DTOs.Order;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(long id);
        Task<List<OrderDTO>> GetAllAsync(int? userId, int? pageNumber, int? pageSize);
        Task<OrderDTO> GetByIdAsync(long id);
    }
}
