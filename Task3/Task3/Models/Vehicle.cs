namespace Task3.Models
{
    public class Vehicle
    {
        private double weight;
        private double volume;

        public VehicleType Type { get; set; }
        public string NumberPlate { get; set; }

        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value > 0)
                {
                    weight = value;
                }
            }
        }
        public double Volume
        {
            get
            {
                return volume;
            }
            set
            {
                if (value > 0)
                {
                    volume = value;
                }
            }
        }

        public Vehicle(string NumberPlate, VehicleType Type, double Weight, double Volume)
        {
            this.NumberPlate = NumberPlate;
            this.Type = Type;
            this.Weight = Weight;
            this.Volume = Volume;
        }
    }
}