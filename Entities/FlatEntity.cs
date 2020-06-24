using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class FlatEntity
    {
            public int ID { get; set; }

            int _apartmentNumber;
            [Required]
            public int ApartmentNumber
            {
                get { return _apartmentNumber; }
                set
                {
                    if (value < 1 && value > 150)
                    {
                        throw new Exception("Квартиры в доме нумеруются от 1 до 150");
                    }
                    else _apartmentNumber = value;
                }
            }

            float _area;
            [Required]
            public float Area
            {
                get { return _area; }
                set
                {
                    if (value <= 0)
                        throw new Exception("Квартиры с площадью меньше 0 не существуют");
                    else _area = value;

                }
            }
            [Required]
            public OwnerEntity Owner { get; set; }
            public int OwnerId { get; set; }
            [Required]
            public HouseEntity House { get; set; }
            public int HouseId { get; set; } 
     }
}
