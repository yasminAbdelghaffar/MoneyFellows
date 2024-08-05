using Core.DTOs.Product;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Order
{
    internal class OrderDTO
    {
        public int Id { get; set; }
        [Required]
        public string DeliveryAddress { get; set; }
        [Required]
        public decimal TotalCost { get; set; }
        [Required]
        public int User { get; set; }
        [Required]
        public DateTime DeliveryTime { get; set; }
        List<ProductDTO>  Products { get; set; }
    }
}
