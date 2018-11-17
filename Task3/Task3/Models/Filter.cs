using System;

namespace Task3.Models
{
    public class Filter
    {
        public DateTime? MinDateOfPosting { get; set; }
        public DateTime? MaxDateOfPosting { get; set; }

        public Destination From { get; set; }
        public Destination To { get; set; }
        public DateTime? MinDateOfLoading { get; set; }
        public DateTime? MaxDateOfLoading { get; set; }

        public VehicleType? Type { get; set; }
        public double? MinWeight { get; set; }
        public double? MaxWeight { get; set; }

        public double? MinVolume { get; set; }
        public double? MaxVolume { get; set; }

        public Filter(DateTime? MinDateOfPosting = null, DateTime? MaxDateOfPosting = null,
            Destination From = null, Destination To = null,
            DateTime? MinDateOfLoading = null, DateTime? MaxDateOfLoading = null,
            VehicleType? Type = null,
            double? MinWeight = null, double? MaxWeight = null,
            double? MinVolume = null, double? MaxVolume = null)
        {
            this.MinDateOfPosting = MinDateOfPosting;
            this.MaxDateOfPosting = MaxDateOfPosting;

            this.From = From;
            this.To = To;

            this.MinDateOfLoading = MinDateOfLoading;
            this.MaxDateOfLoading = MaxDateOfLoading;

            this.Type = Type;

            this.MinWeight = MinWeight;
            this.MaxWeight = MaxWeight;

            this.MinVolume = MinVolume;
            this.MaxVolume = MaxVolume;
        }
    }
}