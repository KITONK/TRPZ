using System;
using System.ComponentModel.DataAnnotations;

namespace ResidentialComplex.DataAccessLayer.Entities
{
    public class HousingDepartamentEntity
    {
        public int ID { get; set; }

        double _pay;
        [Required]
        public double Pay
        {
            get { return _pay; }
            set
            {
                if (value <= 0)
                    throw new Exception("Тариф не может быть меньше 0!");
                else _pay = value;
            }
        }
        [Required]
        public string Name { get; set; }
        [Required]
        public FlatEntity Flat { get; set; }
    }
}
