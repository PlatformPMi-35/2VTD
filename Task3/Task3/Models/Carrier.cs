﻿namespace Task3.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Represent Carrier
    /// </summary>
    [Serializable]
    public class Carrier
    {       
        /// <summary>
        /// Initializes a new instance of the <see cref="Carrier" /> class.
        /// </summary>
        /// <param name="name"> Name of Carrier</param>
        /// <param name="phoneNumber">Phone number of Carrier</param>
        /// <param name="email">Email of Carrier</param>
        /// <param name="vehicle">Vehicle of Carrier</param>
        public Carrier(string name, string phoneNumber, string email, Vehicle vehicle)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Vehicle = vehicle;
        }

        /// <summary>
        /// Gets or sets <see cref="Name"/> for <see cref="Carrier"/>.
        /// </summary>
        /// <value><see cref="Name"/> for <see cref="Carrier"/>.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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
        /// To String Method for Carrier
        /// </summary>
        /// <returns>String with Carrier info</returns>
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.Name, this.PhoneNumber, this.Email);
        }
    }
}
