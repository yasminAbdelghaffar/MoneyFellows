using Core.DTOs.Product;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDBContext _context;

        public OrderRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task AddAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDTO>> GetAllAsync(int? userId, int? pageNumber, int? pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
