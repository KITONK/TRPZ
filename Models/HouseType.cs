﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class HouseType
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

        public HouseType() { }
        public HouseType(int numberOfHouse)
        {
            NumberOfHouse = numberOfHouse;
        }
    }
}
