namespace Task3.Models
{
    using System;

    /// <summary>
    /// Represent offer
    /// </summary>
    [Serializable]
    class Offer
    {
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Offer" /> class.
        /// </summary>
        /// <param name="Id">Offer id</param>
        /// <param name="DateOfPosting">Date of offer posting</param>
        /// <param name="From">Place of load dispatch</param>
        /// <param name="To">Load destination</param>
        /// <param name="DateOfLoading">Date of loading</param>
        /// <param name="VehicleInfo">Information about the vehicle</param>
        /// <param name="CarrierInfo">Information about the carrier</param>
        public Offer(int Id, DateTime DateOfPosting, string From, string To,
            DateTime DateOfLoading, Vehicle VehicleInfo, Carrier CarrierInfo)
        {
            this.Id = Id;
            this.DateOfPosting = DateOfPosting;
            this.From = From;
            this.To = To;
            this.DateOfLoading = DateOfLoading;
            this.VehicleInfo = VehicleInfo;
            this.CarrierInfo = CarrierInfo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Offer" /> class.
        /// </summary>
        /// <param name="Id">Offer id</param>
        /// <param name="DateOfPosting">Date of offer posting</param>
        /// <param name="From">Place of load dispatch</param>
        /// <param name="To">Load destination</param>
        /// <param name="DateOfLoading">Date of loading</param>
        /// <param name="Type">Type of vehicle</param>
        /// <param name="Weight">Vehicle carrying capacity</param>
        /// <param name="Name"> Name of Carrier</param>
        /// <param name="PhoneNumber">Phone number of Carrier</param>
        /// <param name="Email">Email of Carrier</param>
        public Offer(
                    int Id, DateTime DateOfPosting, string From, string To, DateTime DateOfLoading,
                    VehicleType Type, double Weight,
                    string Name, string PhoneNumber, string Email
                    ) : this(
                            Id, DateOfPosting, From, To, DateOfLoading,
                            new Vehicle(Type, Weight), new Carrier(Name, PhoneNumber, Email, new Vehicle(Type, Weight))
                            )
        { }
        
    }
}
