using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public Flat flat;
        public HousingDepartament housingDepartament;

        public Owner(string name, string phoneNumber, DateTime dateOfPurchase)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            DateOfPurchase = dateOfPurchase;
        }

        public Owner() { }
    }
}
