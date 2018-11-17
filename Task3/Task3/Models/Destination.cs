namespace Task3.Models
{
    using System;

    [Serializable]
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
