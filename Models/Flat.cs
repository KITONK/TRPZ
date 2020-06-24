using System;

namespace Models
{
    public class Flat
    {
        public int Id { get; set; }
        int _apartmentNumber;
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

        public Owner Owner { get; set; }
        public House House { get; set; }

        public Flat(House house, int apartmentNumber, float area, Owner owner)
        {
            House = house;
            ApartmentNumber = apartmentNumber;
            Area = area;
            Owner = owner;
       }
        
        public Flat() { }
    }
}
