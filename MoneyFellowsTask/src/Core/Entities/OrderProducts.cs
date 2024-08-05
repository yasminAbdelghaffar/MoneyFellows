using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class OrderProducts
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
