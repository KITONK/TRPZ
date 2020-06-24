using System.ComponentModel.DataAnnotations;
using System;

namespace Entities
{
    public class OwnerEntity
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime DateOfPurchase { get; set; }
    }
}
