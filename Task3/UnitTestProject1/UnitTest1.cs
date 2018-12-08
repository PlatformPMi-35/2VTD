using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3.Controllers;
using Task3.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class TestIOController
    {
        [TestMethod]
        public void SaveLoad()
        {
            int id = 0;
            DateTime dateOfPosting = DateTime.Now;
            string from = "Ukraine";
            string to = "Poland";
            DateTime dateOfLoading = DateTime.Now;
            Vehicle vehicle = new Vehicle(1, VehicleType.Box, 25);
            Carrier carrier = new Carrier(1, "John", "+123456789", "smith@gmail.com", vehicle);

            Offer offer = new Offer(id, dateOfPosting, from, to, dateOfLoading, vehicle, carrier);
            List<Offer> l = new List<Offer>();
            l.Add(offer);
            IOConroller.SaveOffer(@"../../TestSave.bin", l);
            var readed = IOConroller.LoadOffer(@"../../TestSave.bin")[0];

            Assert.IsTrue(
                //readed.Id == id &&
                readed.DateOfPosting == dateOfPosting &&
                readed.From == from &&
                readed.To == to &&
                readed.DateOfLoading == dateOfLoading &&
                readed.VehicleInfo.Type == vehicle.Type &&
                readed.VehicleInfo.Weight == vehicle.Weight &&
                readed.CarrierInfo.Name == carrier.Name &&
                readed.CarrierInfo.PhoneNumber == carrier.PhoneNumber &&
                readed.CarrierInfo.Email == carrier.Email &&
                readed.CarrierInfo.Vehicle.Type == vehicle.Type &&
                readed.CarrierInfo.Vehicle.Weight == vehicle.Weight);

        }
    }

    [TestClass]
    public class TestOfferController
    {
        [TestMethod]
        public void GetOffersFilter()
        {
            int id = 0;
            DateTime dateOfPosting = DateTime.Now;
            string from = "Ukraine";
            string to = "Poland";
            DateTime dateOfLoading = DateTime.Now;
            Vehicle vehicle = new Vehicle(1, VehicleType.Box, 25);
            Carrier carrier = new Carrier(1, "John", "+123456789", "smith@gmail.com", vehicle);

            Offer offer = new Offer(id, dateOfPosting, from, to, dateOfLoading, vehicle, carrier);

            Filter filter = new Filter(minDateOfPosting: dateOfPosting, 
                from: from, 
                type: vehicle.Type,
                maxWeight: vehicle.Weight
                );

            OfferController offerController = new OfferController();
            offerController.AddOffer(offer);
            var res = offerController.GetOffers(filter);
            Assert.IsTrue(res.Count == 1);
        }
    }
}
