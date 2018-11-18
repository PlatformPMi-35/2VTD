namespace Task3.Models
{
    using System;

    [Serializable]
    public class Vehicle
    {
        private double weight;
        private double volume;

        public VehicleType Type { get; set; }

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

        public Vehicle(VehicleType Type, double Weight, double Volume)
        {
            this.Type = Type;
            this.Weight = Weight;
            this.Volume = Volume;
        }

        public override string ToString()
        {
            return string.Format("{0:F}", Weight);
        }
    }
}