using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class HouseTypeEntity
    {
        public int Id { get; set; }

        [Required]
        public int NumberOfHouse { get; set; }
    }
}
