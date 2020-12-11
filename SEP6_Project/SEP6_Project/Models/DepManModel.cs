using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_Project.Models
{
    public class DepManModel
    { 
        // Mean departure delays
        public double mean_dep_LGA { get; set; }
        public double mean_dep_EWR { get; set; }
        public double mean_dep_JFK { get; set; }

        // Mean arrival delays
        public double mean_arr_LGA { get; set; }
        public double mean_arr_EWR { get; set; }
        public double mean_arr_JFK { get; set; }


        // Manufacturer
        public List<Manufacturer> big_manufacturers { get; set; }

        public List<Manufacturer> manufacturers_with_flights { get; set; }

        public List<(string, int)> airbus_models { get; set; }


    }
}
