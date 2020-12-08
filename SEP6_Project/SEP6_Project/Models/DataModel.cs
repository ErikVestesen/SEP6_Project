using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_Project.Models
{
    public class DataModel
    {
        public IDictionary<int, int> flights = new Dictionary<int, int>();

        public List<int> flightsJFK { get; set; }
        public List<int> flightsEWR { get; set; }
        public List<int> flightsLGA { get; set; }

        public IDictionary<string, int> top10flights { get; set; }
        public IDictionary<string, int> top10flights_origin { get; set; }

        public List<int> topflightsJFK { get; set; }
        public List<int> topflightsEWR { get; set; }
        public List<int> topflightsLGA { get; set; }
    }
}
