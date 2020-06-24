using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models
{
    public class House
    {
        public int Id { get; set; }
        public HouseType Type { get; set; }
        public string Address { get; set; }
       // public List<Flat> Flats { get; set; }

        public House(HouseType type, string address)
        {
            Type = type;
            Address = address;
            //Flats = new List<Flat>(flats);
        }

        public House() { }
    }

}
