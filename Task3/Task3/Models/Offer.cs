namespace Task3.Models
{
    using System;

    [Serializable]
    class Offer
    {
        //Information about the offer
        public int Id { get; set; }
        public DateTime DateOfPosting { get; set; }

        //Information about the loading
        public string From { get; set; }
        public string To { get; set; }
        public DateTime DateOfLoading { get; set; }

        //Information about the vehicle
        public Vehicle VehicleInfo { get; set; }

        //Information about the carrier
        public Carrier CarrierInfo { get; set; }

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
        public Offer(
                    int Id, DateTime DateOfPosting, string From, string To, DateTime DateOfLoading,
                    VehicleType Type, double Weight, double Volume,
                    string Name, string PhoneNumber, string Email
                    ) : this(
                            Id, DateOfPosting, From, To, DateOfLoading,
                            new Vehicle(Type, Weight, Volume), new Carrier(Name, PhoneNumber, Email, new Vehicle(Type, Weight, Volume))
                            )
        { }
        
    }
}
