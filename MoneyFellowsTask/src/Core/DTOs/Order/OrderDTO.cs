using Core.DTOs.Product;
using Core.Validators;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Order
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal TotalCost { get; set; }
        public int User { get; set; }
        public DateTime DeliveryTime { get; set; }
        public List<OrderDetailsDTO>  OrderDetails { get; set; }
    }
}
