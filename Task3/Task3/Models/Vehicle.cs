namespace Task3.Models
{
    using System;

    /// <summary>
    /// Represent vehicle
    /// </summary>
    [Serializable]
    public class Vehicle
    {
        /// <summary>
        /// Vehicle carrying capacity
        /// </summary>
        private double weight;

        /// <summary>
        /// Gets or sets <see cref="Type"/> for <see cref="Vehicle"/>.
        /// </summary>
        public VehicleType Type { get; set; }

        /// <summary>
        /// Gets or sets <see cref="Weight"/> for <see cref="Vehicle"/>.
        /// </summary>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle" /> class.
        /// </summary>
        /// <param name="Type">Type of vehicle</param>
        /// <param name="Weight">Vehicle carrying capacity</param>
        public Vehicle(VehicleType Type, double Weight)
        {
            this.Type = Type;
            this.Weight = Weight;
        }

        /// <summary>
        /// To String Method for Vehicle
        /// </summary>
        /// <returns>String with Vehicle info</returns>
        public override string ToString()
        {
            return string.Format("{0:F}", Weight);
        }
    }
}