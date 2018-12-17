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
            Carrier carrier = new Carrier(1, "John", "+123456789", "smith@gmail.com", 1);
            Offer offer = new Offer(id, dateOfPosting, from, to, dateOfLoading, 1);

            UnitOfWork uow = new UnitOfWork("TestDb");
            uow.Vehicles.Create(vehicle);
            uow.Carriers.Create(carrier);
            uow.Offers.Create(offer);
            uow.Save();

            Vehicle v = uow.Vehicles.Get(1);
            Carrier c = uow.Carriers.Get(1);
            Offer o = uow.Offers.Get(1);

            uow.Vehicles.Delete(1);
            uow.Carriers.Delete(1);
            uow.Carriers.Delete(1);
            uow.Save();

            Assert.IsTrue(
                o.OfferId == offer.OfferId &&
                o.DateOfPosting == offer.DateOfPosting &&
                o.From == offer.From &&
                o.To == offer.To &&
                o.DateOfLoading == offer.DateOfLoading &&
                o.CarrierId == offer.CarrierId &&

                c.CarrierId == carrier.CarrierId &&
                c.Name == carrier.Name &&
                c.PhoneNumber == carrier.PhoneNumber &&
                c.Email == carrier.Email &&
                c.VehicleId == carrier.VehicleId &&

                v.VehicleId == vehicle.VehicleId &&
                v.Type == vehicle.Type &&
                v.Weight == vehicle.Weight);
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
            Vehicle vehicle = new Vehicle()
            {
                VehicleId = 1,
                Type = VehicleType.Box,
                Weight = 25
            };
            Carrier carrier = new Carrier()
            {
                CarrierId = 1,
                Name = "John",
                Email = "smith@gmail.com",
                PhoneNumber = "+123456789",
                VehicleId = 1,
                Vehicle = vehicle
            };
            Offer offer = new Offer()
            {
                OfferId = id,
                DateOfLoading = dateOfLoading,
                DateOfPosting = dateOfPosting,
                From = from,
                To = to,
                CarrierId = 1,
                Carrier = carrier
            };
            
            Filter filter = new Filter(
                
                minDateOfPosting: dateOfPosting,
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
