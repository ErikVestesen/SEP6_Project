using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_Project.Models
{
    public class Temperature
    {
        public string origin { get; set; }
        public double daily_mean { get; set; }

        public int day { get; set; }

        public int month { get; set; }

        public int year { get; set; }

         
        public Temperature(string origin, double daily_mean, int day, int month, int year)
        {
            this.origin = origin;
            this.daily_mean = daily_mean;
            this.day = day;
            this.month = month;
            this.year = year;
        } 
    }
}
