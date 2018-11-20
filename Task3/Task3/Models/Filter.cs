namespace Task3.Models
{
    using System;

    /// <summary>
    /// Instrument for offer filtration
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// Gets or sets <see cref="MinDateOfPosting"/> for <see cref="Filter"/>.
        /// </summary>
        public DateTime? MinDateOfPosting { get; set; }

        /// <summary>
        /// Gets or sets <see cref="MaxDateOfPosting"/> for <see cref="Filter"/>.
        /// </summary>
        public DateTime? MaxDateOfPosting { get; set; }

        /// <summary>
        /// Gets or sets <see cref="From"/> for <see cref="Filter"/>.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Gets or sets <see cref="To"/> for <see cref="Filter"/>.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Gets or sets <see cref="MinDateOfLoading"/> for <see cref="Filter"/>.
        /// </summary>
        public DateTime? MinDateOfLoading { get; set; }

        /// <summary>
        /// Gets or sets <see cref="MaxDateOfLoading"/> for <see cref="Filter"/>.
        /// </summary>
        public DateTime? MaxDateOfLoading { get; set; }

        /// <summary>
        /// Gets or sets <see cref="Type"/> for <see cref="Filter"/>.
        /// </summary>
        public VehicleType? Type { get; set; }

        /// <summary>
        /// Gets or sets <see cref="MinWeight"/> for <see cref="Filter"/>.
        /// </summary>
        public double? MinWeight { get; set; }

        /// <summary>
        /// Gets or sets <see cref="MaxWeight"/> for <see cref="Filter"/>.
        /// </summary>
        public double? MaxWeight { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="Filter" /> class.
        /// </summary>
        /// <param name="MinDateOfPosting">Min date of offer posting</param>
        /// <param name="MaxDateOfPosting">Max date of offer posting</param>
        /// <param name="From">Place of load dispatch</param>
        /// <param name="To">Load destination</param>
        /// <param name="MinDateOfLoading">Min date of loading</param>
        /// <param name="MaxDateOfLoading">Max date of loading</param>
        /// <param name="Type">Vehicle type</param>
        /// <param name="MinWeight">Min carrying capacity of the vehicle</param>
        /// <param name="MaxWeight">Max carrying capacity of the vehicle</param>
        public Filter(DateTime? MinDateOfPosting = null, DateTime? MaxDateOfPosting = null,
            string From = null, string To = null,
            DateTime? MinDateOfLoading = null, DateTime? MaxDateOfLoading = null,
            VehicleType? Type = null,
            double? MinWeight = null, double? MaxWeight = null)
        {
            this.MinDateOfPosting = MinDateOfPosting;
            this.MaxDateOfPosting = MaxDateOfPosting;

            this.From = From;
            this.To = To;

            this.MinDateOfLoading = MinDateOfLoading;
            this.MaxDateOfLoading = MaxDateOfLoading;

            if ((int)Type == -1)
            {
                Type = null;
            }

            this.Type = Type;

            this.MinWeight = MinWeight;
            this.MaxWeight = MaxWeight;
        }
    }
}