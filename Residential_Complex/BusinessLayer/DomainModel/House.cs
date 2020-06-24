using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ResidentialComplex.BusinessLayer.DomainModel
{
    public class House
    {
        public int Id { get; set; }
        int _numberOfHouse;
        public int NumberOfHouse
        {
            get { return _numberOfHouse; }
            set
            {
                if (value <= 0 && value > 4)
                {
                    throw new Exception("ЖК имеет всего 4 дома");
                }
                else _numberOfHouse = value;
            }
        }
        public string Address { get; set; }
       // public List<Flat> Flats { get; set; }

        public House(int numberOfHouse, string address)
        {
            NumberOfHouse = numberOfHouse;
            Address = address;
            //Flats = new List<Flat>(flats);
        }

        public House() { }
    }

}
