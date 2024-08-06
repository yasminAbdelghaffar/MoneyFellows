using Core.DTOs.Order;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDBContext _context;

        public OrderRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Order order)
        {
            _context.Order.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            _context.Order.Remove(_context.Order.FirstOrDefault(x => x.Id == id));
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Order.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task<List<OrderDTO>> GetAllAsync(int? userId, int? pageNumber, int? pageSize)
        {
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 10;

            return await _context.Order.AsNoTracking().Where(x => userId == null).Select(o => new OrderDTO() //User to be added in DB then checked here
            {
                DeliveryAddress = o.DeliveryAddress,
                DeliveryTime = o.DeliveryTime,
                Id  = o.Id, 
                TotalCost = o.TotalCost,
                User = o.UserId,
            }).Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).ToListAsync();
        }

        public async Task<OrderDTO> GetByIdAsync(long id)
        {
            return await _context.Order.AsNoTracking().Where(x => x.Id == id).Select(o => new OrderDTO()
            {
                DeliveryAddress = o.DeliveryAddress,
                DeliveryTime = o.DeliveryTime,
                Id = o.Id,
                TotalCost = o.TotalCost,
                User = o.UserId,
            }).FirstOrDefaultAsync();
        }
    }
}
