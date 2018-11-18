namespace Task3.Models
{
    using System;

    [Serializable]
    public class Vehicle
    {
        private double weight;

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

        public Vehicle(VehicleType Type, double Weight)
        {
            this.Type = Type;
            this.Weight = Weight;
        }

        public override string ToString()
        {
            return string.Format("{0:F}", Weight);
        }
    }
}