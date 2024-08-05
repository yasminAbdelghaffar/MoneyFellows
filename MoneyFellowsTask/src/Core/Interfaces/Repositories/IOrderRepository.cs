using Core.DTOs.Product;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(long id);
        Task<List<ProductDTO>> GetAllAsync(int? userId, int? pageNumber, int? pageSize);
        Task<ProductDTO> GetByIdAsync(long id);
    }
}
