using Core.DTOs.Product;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(long id);
        Task<List<ProductDTO>> GetAllAsync(string? merchant, int? pageNumber, int? pageSize);
        Task<ProductDTO> GetByIdAsync(long id);
    }
}
