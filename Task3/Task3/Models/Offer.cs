namespace Task3.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// This class represents offers.
    /// </summary>
    [Serializable]
    public class Offer
    {
        /// <summary>
        /// This class Initializes a new instance of the <see cref="Offer"/> class.
        /// </summary>
        /// <param name="offerId">Id of the Offer.</param>
        /// <param name="dateOfPosting">Date of offer posting.</param>
        /// <param name="from">Place of load dispatch.</param>
        /// <param name="to">Load destination.</param>
        /// <param name="dateOfLoading">Date of loading.</param>     
        /// <param name="carrierId">Id of the carrier.</param>
        public Offer(
            int offerId, 
            DateTime dateOfPosting, 
            string from, 
            string to,
            DateTime dateOfLoading,
            int carrierId)
        {
            this.OfferId = offerId;
            this.DateOfPosting = dateOfPosting;
            this.From = from;
            this.To = to;
            this.DateOfLoading = dateOfLoading;
            this.CarrierId = carrierId;
        }

        /// <summary>
        /// This functoin initializes a new instance of the <see cref="Offer" /> class.
        /// </summary>
        public Offer()
        {
            Carrier = new Carrier();
        }

        /// <summary>
        /// Gets or sets <see cref="Id"/> for <see cref="Offer"/>.
        /// </summary>
        /// <value>Id of the Offer.</value>
        [Key]
        public int OfferId { get; set; }

        /// <summary>
        /// Gets or sets <see cref="DateOfPosting"/> for <see cref="Offer"/>.
        /// </summary>
        /// <value>DateOfPosting of the Offer.</value>
        public DateTime DateOfPosting { get; set; }

        /// <summary>
        /// Gets or sets <see cref="From"/> for <see cref="Offer"/>.
        /// </summary>
        /// <value>Driving From of the Offer.</value>
        public string From { get; set; }

        /// <summary>
        /// Gets or sets <see cref="To"/> for <see cref="Offer"/>.
        /// </summary>
        /// <value>Driving To of the Offer.</value>
        public string To { get; set; }

        /// <summary>
        /// Gets or sets <see cref="DateOfLoading"/> for <see cref="Offer"/>.
        /// </summary>
        /// <value>DateOfLoading of the Offer.</value>
        public DateTime DateOfLoading { get; set; }

        /// <summary>
        /// Gets or sets <see cref="CarrierId"/> for <see cref="Offer"/>.
        /// </summary>
        /// <value>CarrierId of the Offer.</value>
        public int CarrierId { get; set; }

        /// <summary>
        /// Gets or sets <see cref="CarrierInfo"/> for <see cref="Offer"/>.
        /// </summary>
        /// <value>Carrier of the Offer.</value>
        public Carrier Carrier { get; set; }
    }
}
