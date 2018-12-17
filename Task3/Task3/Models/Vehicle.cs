namespace Task3.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represent vehicle.
    /// </summary>
    [Serializable]
    public class Vehicle
    {
        /// <summary>
        /// Vehicle carrying capacity.
        /// </summary>
        private double weight;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle" /> class.
        /// </summary>
        /// <param name="id">Id of the Vehicle.</param>
        /// <param name="type">Type of vehicle.</param>
        /// <param name="weight">Vehicle carrying capacity.</param>
        public Vehicle(int id, VehicleType type, double weight)
        {
            this.VehicleId = id;
            this.Type = type;
            this.Weight = weight;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle" /> class.
        /// </summary>
        public Vehicle()
        {
        }

        /// <summary>
        /// Gets or sets <see cref="Id"/> for <see cref="Vehicle"/>.
        /// </summary>
        /// <value>Id of the <see cref="Vehicle"/>.</value>
        [Key]
        public int VehicleId { get; set; }

        /// <summary>
        /// Gets or sets <see cref="Type"/> for <see cref="Vehicle"/>.
        /// </summary>
        /// <value>Type of the <see cref="Vehicle"/>.</value>
        public VehicleType Type { get; set; }

        /// <summary>
        /// Gets or sets <see cref="Weight"/> for <see cref="Vehicle"/>.
        /// </summary>
        /// <value>Weight of the <see cref="Vehicle"/>.</value>
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
        /// To String Method for Vehicle.
        /// </summary>
        /// <returns>String with Vehicle info.</returns>
        public override string ToString()
        {
            return string.Format("{0:F}", this.Weight);
        }
    }
}