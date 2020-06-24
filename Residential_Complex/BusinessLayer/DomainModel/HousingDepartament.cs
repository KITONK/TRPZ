using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ResidentialComplex.BusinessLayer.DomainModel
{
    public class HousingDepartament
    {
        public int Id { get; set; }
        double _pay;
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
        public string Name { get; set; }
        public Flat Flat { get; set; }
        public House House { get; set; }

        public HousingDepartament(double pay, string name, Flat flat)
        {
            Pay = pay;
            Name = name;
            Flat = flat;
        }

        public HousingDepartament() { }


    }
}
