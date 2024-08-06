using Core.Validators;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Product
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required, AlphaNumeric]
        public string ProductName { get; set; }
        [Required, AlphaNumeric]
        public string ProductDescription { get; set; }
        public byte[]? ProductImage { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required, AlphaNumeric]
        public string Merchant { get; set; }
    }
}
