namespace Task3.Models
{
    using System;

    /// <summary>
    /// Represent Carrier
    /// </summary>
    [Serializable]
    class Carrier
    {
        /// <summary>
        /// Gets or sets <see cref="Name"/> for <see cref="Carrier"/>.
        /// </summary>
        /// <value><see cref="Name"/> for <see cref="Carrier"/>.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets <see cref="PhoneNumber"/> for <see cref="Carrier"/>.
        /// </summary>
        /// <value><see cref="PhoneNumber"/> for <see cref="Carrier"/>.</value>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets <see cref="Email"/> for <see cref="Carrier"/>.
        /// </summary>
        /// <value><see cref="Email"/> for <see cref="Carrier"/>.</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets <see cref="Vehicle"/> for <see cref="Carrier"/>.
        /// </summary>
        /// <value><see cref="Vehicle"/> for <see cref="Carrier"/>.</value>
        public Vehicle Vehicle { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Carrier" /> class.
        /// </summary>
        /// <param name="Name"> Name of Carrier</param>
        /// <param name="PhoneNumber">Phone number of Carrier</param>
        /// <param name="Email">Email of Carrier</param>
        /// <param name="Vehicle">Vehicle of Carrier</param>
        public Carrier(string Name, string PhoneNumber, string Email, Vehicle Vehicle)
        {
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.Vehicle = Vehicle;
        }

        /// <summary>
        /// To String Method for Carrier
        /// </summary>
        /// <returns>String with Carrier info</returns>
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Name, PhoneNumber, Email);
        }
    }
}
