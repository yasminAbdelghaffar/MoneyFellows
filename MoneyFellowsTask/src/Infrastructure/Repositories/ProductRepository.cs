using Core.DTOs.Product;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;

        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            _context.Product.Remove(_context.Product.FirstOrDefault(x => x.Id == id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductDTO>> GetAllAsync(string? merchant, int? pageNumber, int? pageSize)
        {
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 10;

            return await _context.Product.AsNoTracking().Where(x => string.IsNullOrWhiteSpace(merchant) || x.Merchant == merchant).Select(p => new ProductDTO()
            {
                Merchant = p.Merchant,
                Price = p.Price,
                ProductDescription = p.ProductDescription,
                ProductName = p.ProductName,
                ProductImage = p.ProductImage
            }).Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).ToListAsync();
        }

        public async Task<ProductDTO> GetByIdAsync(long id)
        {
            return await _context.Product.AsNoTracking().Where(x => x.Id == id).Select(p => new ProductDTO()
            {
                Merchant = p.Merchant,
                Price = p.Price,
                ProductDescription = p.ProductDescription,
                ProductName = p.ProductName,
                ProductImage = p.ProductImage
            }).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Product.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
