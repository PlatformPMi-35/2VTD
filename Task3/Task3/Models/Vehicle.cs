namespace Task3.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Represent vehicle
    /// </summary>
    [Serializable]
    public class Vehicle
    {
        /// <summary>
        /// Gets or sets <see cref="Id"/> for <see cref="Vehicle"/>.
        /// </summary>
        [Key]
        //[ForeignKey("Carrier")]
        public int VehicleId { get; set; }

        /// <summary>
        /// Vehicle carrying capacity
        /// </summary>
        private double weight;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle" /> class.
        /// </summary>
        /// <param name="type">Type of vehicle</param>
        /// <param name="weight">Vehicle carrying capacity</param>
        public Vehicle(int id, VehicleType type, double weight)
        {
            this.VehicleId = id;
            this.Type = type;
            this.Weight = weight;
        }

        public Vehicle()
        {

        }

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
                return this.weight;
            }

            set
            {
                if (value > 0)
                {
                    this.weight = value;
                }
            }
        }

        /// <summary>
        /// To String Method for Vehicle
        /// </summary>
        /// <returns>String with Vehicle info</returns>
        public override string ToString()
        {
            return string.Format("{0:F}", this.Weight);
        }
    }
}