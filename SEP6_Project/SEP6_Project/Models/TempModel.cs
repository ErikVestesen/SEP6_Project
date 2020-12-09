using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_Project.Models
{
    public class TempModel
    {

        public List<Temperature> daily_temp_JFK { get; set; }

        public List<Temperature> daily_temp_EWR { get; set; }

        public List<Temperature> daily_temp_LGA { get; set; }


        public List<Temperature> temp_JFK { get; set; }
        public List<Temperature> temp_EWR { get; set; }
        public List<Temperature> temp_LGA { get; set; }


    }
}
