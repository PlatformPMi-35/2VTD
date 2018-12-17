namespace Task3.Models
{
    using System;

    /// <summary>
    /// Instrument for offer filtration.
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Filter" /> class.
        /// </summary>
        /// <param name="minDateOfPosting">Min date of offer posting.</param>
        /// <param name="maxDateOfPosting">Max date of offer posting.</param>
        /// <param name="from">Place of load dispatch.</param>
        /// <param name="to">Load destination.</param>
        /// <param name="minDateOfLoading">Min date of loading.</param>
        /// <param name="maxDateOfLoading">Max date of loading.</param>
        /// <param name="type">Vehicle type.</param>
        /// <param name="minWeight">Min carrying capacity of the vehicle.</param>
        /// <param name="maxWeight">Max carrying capacity of the vehicle.</param>
        public Filter(
            DateTime? minDateOfPosting = null, 
            DateTime? maxDateOfPosting = null,
            string from = null, 
            string to = null,
            DateTime? minDateOfLoading = null, 
            DateTime? maxDateOfLoading = null,
            VehicleType? type = null,
            double? minWeight = null, 
            double? maxWeight = null)
        {
            this.MinDateOfPosting = minDateOfPosting;
            this.MaxDateOfPosting = maxDateOfPosting;

            this.From = from;
            this.To = to;

            this.MinDateOfLoading = minDateOfLoading;
            this.MaxDateOfLoading = maxDateOfLoading;

            if ((int)type == -1)
            {
                type = null;
            }

            this.Type = type;

            this.MinWeight = minWeight;
            this.MaxWeight = maxWeight;
        }

        /// <summary>
        /// Gets or sets <see cref="MinDateOfPosting"/> for <see cref="Filter"/>.
        /// </summary>
        /// <value>Min Date Of Posting.</value>
        public DateTime? MinDateOfPosting { get; set; }

        /// <summary>
        /// Gets or sets <see cref="MaxDateOfPosting"/> for <see cref="Filter"/>.
        /// </summary>
        /// <value>Max Date Of Posting.</value>
        public DateTime? MaxDateOfPosting { get; set; }

        /// <summary>
        /// Gets or sets <see cref="From"/> for <see cref="Filter"/>.
        /// </summary>
        /// <value>Driving From.</value>
        public string From { get; set; }

        /// <summary>
        /// Gets or sets <see cref="To"/> for <see cref="Filter"/>.
        /// </summary>
        /// <value>Driving To.</value>
        public string To { get; set; }

        /// <summary>
        /// Gets or sets <see cref="MinDateOfLoading"/> for <see cref="Filter"/>.
        /// </summary>
        /// <value>Min Date Of Loading.</value>
        public DateTime? MinDateOfLoading { get; set; }

        /// <summary>
        /// Gets or sets <see cref="MaxDateOfLoading"/> for <see cref="Filter"/>.
        /// </summary>
        /// <value>Max Date Of Loading.</value>
        public DateTime? MaxDateOfLoading { get; set; }

        /// <summary>
        /// Gets or sets <see cref="Type"/> for <see cref="Filter"/>.
        /// </summary>
        /// <value>Type of <see cref="Vehicle"/>.</value>
        public VehicleType? Type { get; set; }

        /// <summary>
        /// Gets or sets <see cref="MinWeight"/> for <see cref="Filter"/>.
        /// </summary>
        /// <value>Min Weight of <see cref="Vehicle"/>.</value>
        public double? MinWeight { get; set; }

        /// <summary>
        /// Gets or sets <see cref="MaxWeight"/> for <see cref="Filter"/>.
        /// </summary>
        /// <value>Max Weight of <see cref="Vehicle"/>.</value>
        public double? MaxWeight { get; set; }
    }
}