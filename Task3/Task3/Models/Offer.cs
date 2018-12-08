namespace Task3.Models
{
    using System;

    /// <summary>
    /// Represent offer
    /// </summary>
    [Serializable]
    public class Offer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Offer" /> class.
        /// </summary>
        /// <param name="id">Offer id</param>
        /// <param name="dateOfPosting">Date of offer posting</param>
        /// <param name="from">Place of load dispatch</param>
        /// <param name="to">Load destination</param>
        /// <param name="dateOfLoading">Date of loading</param>
        /// <param name="vehicleInfo">Information about the vehicle</param>
        /// <param name="carrierInfo">Information about the carrier</param>
        public Offer(
            int id, 
            DateTime dateOfPosting, 
            string from, 
            string to,
            DateTime dateOfLoading, 
            Vehicle vehicleInfo, 
            Carrier carrierInfo)
        {
            this.Id = id;
            this.DateOfPosting = dateOfPosting;
            this.From = from;
            this.To = to;
            this.DateOfLoading = dateOfLoading;
            this.VehicleInfo = vehicleInfo;
            this.CarrierInfo = carrierInfo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Offer" /> class.
        /// </summary>
        /// <param name="id">Offer id</param>
        /// <param name="dateOfPosting">Date of offer posting</param>
        /// <param name="from">Place of load dispatch</param>
        /// <param name="to">Load destination</param>
        /// <param name="dateOfLoading">Date of loading</param>
        /// <param name="vehicleId">Vehicle id</param>
        /// <param name="type">Type of vehicle</param>
        /// <param name="weight">Vehicle carrying capacity</param>
        /// <param name="name"> Name of Carrier</param>
        /// <param name="phoneNumber">Phone number of Carrier</param>
        /// <param name="email">Email of Carrier</param>
        public Offer(
                    int id,
                    DateTime dateOfPosting,
                    string from, 
                    string to, 
                    DateTime dateOfLoading,
                    int vehicleId,
                    VehicleType type,
                    double weight,
                    string name, 
                    string phoneNumber, 
                    string email) : 
            this(
                            id, 
                            dateOfPosting, 
                            from, 
                            to, 
                            dateOfLoading,
                            new Vehicle(vehicleId, type, weight), 
                            new Carrier(name, phoneNumber, email, new Vehicle(vehicleId, type, weight)))
        {
        }

        /// <summary>
        /// Gets or sets <see cref="Id"/> for <see cref="Offer"/>.
        /// </summary>
        public int Id { get; set; }

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

        /// <summary>
        /// Gets or sets <see cref="VehicleInfo"/> for <see cref="Offer"/>.
        /// </summary>
        public Vehicle VehicleInfo { get; set; }

        /// <summary>
        /// Gets or sets <see cref="CarrierInfo"/> for <see cref="Offer"/>.
        /// </summary>
        public Carrier CarrierInfo { get; set; }
    }
}
