﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFClean.Console.Entity
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string CarModel { get; set; }
        public string CarColor { get; set; }
        public string CarType { get; set; }
        public int HorsePower { get; set; }
        public string EngineType { get; set; }

    }
}
