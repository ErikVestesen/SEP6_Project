using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_Project.Models
{
    public class Manufacturer
    {
        public string name { get; set; }
        public int plane_count { get; set; }
        public int flight_count { get; set; }

        public Manufacturer() { }
    }
}
