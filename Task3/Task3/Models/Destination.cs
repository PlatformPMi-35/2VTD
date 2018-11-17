using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Models
{
    public class Destination
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }

        public Destination(string Country, string Region, string City)
        {
            this.Country = Country;
            this.Region = Region;
            this.City = City;
        }
    }
}
