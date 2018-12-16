namespace Task3.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Represent offer
    /// </summary>
    [Serializable]
    public class Offer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Offer" /> class.
        /// </summary>
        /// <param name="OfferId">Offer id</param>
        /// <param name="dateOfPosting">Date of offer posting</param>
        /// <param name="from">Place of load dispatch</param>
        /// <param name="to">Load destination</param>
        /// <param name="dateOfLoading">Date of loading</param>
        /// <param name="vehicleInfo">Information about the vehicle</param>
        /// <param name="carrierInfo">Information about the carrier</param>
        public Offer(
            int OfferId, 
            DateTime dateOfPosting, 
            string from, 
            string to,
            DateTime dateOfLoading,
            int carrierId
            )
        {
            this.OfferId = OfferId;
            this.DateOfPosting = dateOfPosting;
            this.From = from;
            this.To = to;
            this.DateOfLoading = dateOfLoading;
            this.CarrierId = carrierId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Offer" /> class.
        /// </summary>
        /// <param name="OfferId">Offer id</param>
        /// <param name="dateOfPosting">Date of offer posting</param>
        /// <param name="from">Place of load dispatch</param>
        /// <param name="to">Load destination</param>
        /// <param name="dateOfLoading">Date of loading</param>
        /// <param name="vehicleId">Vehicle id</param>
        /// <param name="type">Type of vehicle</param>
        /// <param name="weight">Vehicle carrying capacity</param>
        /// <param name="carrierId">Carrier id</param>
        /// <param name="name"> Name of Carrier</param>
        /// <param name="phoneNumber">Phone number of Carrier</param>
        /// <param name="email">Email of Carrier</param>
        //public Offer(
        //            int OfferId,
        //            DateTime dateOfPosting,
        //            string from, 
        //            string to, 
        //            DateTime dateOfLoading,
        //            int vehicleId,
        //            VehicleType type,
        //            double weight,
        //            int carrierId,
        //            string name, 
        //            string phoneNumber, 
        //            string email) : 
        //    this(
        //                    OfferId, 
        //                    dateOfPosting, 
        //                    from, 
        //                    to, 
        //                    dateOfLoading,
        //                    //new Vehicle(vehicleId, type, weight), 
        //                    new Carrier(carrierId, name, phoneNumber, email, new Vehicle(vehicleId, type, weight)))
        //{
        //}

        public Offer()
        {
            Carrier = new Carrier();
        }

        /// <summary>
        /// Gets or sets <see cref="Id"/> for <see cref="Offer"/>.
        /// </summary>
        [Key]
        public int OfferId { get; set; }

        /// <summary>
        /// Gets or sets <see cref="DateOfPosting"/> for <see cref="Offer"/>.
        /// </summary>
        public DateTime DateOfPosting { get; set; }

        /// <summary>
        /// Gets or sets <see cref="From"/> for <see cref="Offer"/>.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Gets or sets <see cref="To"/> for <see cref="Offer"/>.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Gets or sets <see cref="DateOfLoading"/> for <see cref="Offer"/>.
        /// </summary>
        public DateTime DateOfLoading { get; set; }

        public int CarrierId { get; set; }

        /// <summary>
        /// Gets or sets <see cref="CarrierInfo"/> for <see cref="Offer"/>.
        /// </summary>
        public Carrier Carrier { get; set; }
    }
}
