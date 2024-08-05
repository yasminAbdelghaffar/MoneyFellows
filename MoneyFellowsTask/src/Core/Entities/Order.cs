﻿using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Order : AuditEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DeliveryAddress { get; set; }
        [Required]
        public decimal TotalCost { get; set; }
        [Required]
        public int User { get; set; }
        [Required]
        public DateTime DeliveryTime { get; set; }
    }
}