﻿using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Core.Entities
{
    public class Product : AuditEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        public Blob? ProductImage { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Merchant { get; set; }
    }
}
