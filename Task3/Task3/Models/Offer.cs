﻿using System;

namespace Task3.Models
{
    class Offer
    {
        //Information about the offer
        public string Id { get; set; }
        public DateTime DateOfPosting { get; set; }

        //Information about the loading
        public string From { get; set; }
        public string To { get; set; }
        public DateTime DateOfLoading { get; set; }

        //Information about the vehicle
        public Vehicle VehicleInfo { get; set; }

        //Information about the carrier
        public Carrier CarrierInfo { get; set; }

    }
}