using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class HouseEntity
    {
        public int ID { get; set; }

        [Required]
        public HouseTypeEntity Type { get; set; }
        public int TypeId { get; set; }

        //int _numberOfHouse;
        //[Required]
        //public int NumberOfHouse
        //{
        //    get { return _numberOfHouse; }
        //    set
        //    {
        //        if (value <= 0 && value > 4)
        //        {
        //            throw new Exception("ЖК имеет всего 4 дома");
        //        }
        //        else _numberOfHouse = value;
        //    }
        //}
        [Required]
        public string Address { get; set; }
    }
}
