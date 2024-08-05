using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public partial class ApplicationDBContext
    {
        public DbSet<User> User { set; get; }
        public DbSet<Product> Product { set; get; }
        public DbSet<Order> Order { set; get; }
        public DbSet<OrderProducts> OrderProducts { set; get; }
    }
}
