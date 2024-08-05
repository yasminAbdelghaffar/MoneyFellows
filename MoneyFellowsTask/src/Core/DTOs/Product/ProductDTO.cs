using Core.Validators;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Core.DTOs.Product
{
    public class ProductDTO
    {
        [Required]
        [Unique("ProductName")]
        [Alphabetic]
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public Blob? ProductImage { get; set; }
        public decimal Price { get; set; }
        public string Merchant { get; set; }
    }
}
