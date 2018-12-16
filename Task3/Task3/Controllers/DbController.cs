using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Models;

namespace Task3.Controllers
{
    class DbController
    {
        /// <summary>
        /// Saves offers to database
        /// </summary>
        /// <param name="offer"><see cref="IEnumerabl{Offer}"/> to save.</param>
        public static void SaveOffers(List<Offer> offers)
        {
            try
            {
                UnitOfWork unitOfWork = new UnitOfWork();
                foreach (Offer offer in offers)
                {
                    unitOfWork.Offers.Create(offer);
                    unitOfWork.Save();
                }
                //using (OfferContext db = new OfferContext())
                //{
                //    foreach (Offer offer in offers)
                //    {
                //        db.Offers.Add(offer);
                //    }
                //    db.SaveChanges();
                //}
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Load offers from database
        /// </summary>
        /// <returns><see cref="List{Offer}"/> of <see cref="Offer"/>s</returns>
        public static List<Offer> LoadOffers()
        {
            try
            {
                using (OfferContext db = new OfferContext())
                {
                    
                    Offer offer = db.Offers.Include(t => t.Carrier).FirstOrDefault();
                    return new List<Offer>(new[] { offer });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void GenerateRandomDB()
        {
            Random rnd = new Random();
            try
            {
                using (OfferContext db = new OfferContext())
                {
                    string[] countries = File.ReadAllText(@"..\..\Resourses\Countries.txt").Split('\n');
                    string[] names = File.ReadAllText(@"..\..\Resourses\Names.txt").Split('\n');
                    string[] phoneNums = File.ReadAllText(@"..\..\Resourses\PhoneNumbers.txt").Split('\n');
                    OfferController oc = new OfferController();
                    for (int i = 0; i < 1000; ++i)
                    {
                        Vehicle v = new Vehicle(i, (VehicleType)rnd.Next(0, 8), IOConroller.RandomDouble(0.1, 30, rnd));
                        db.Vehicles.AddRange(new List<Vehicle> { v });
                    }
                    for (int i = 0; i < 1000; ++i)
                    {
                        string name = IOConroller.RandomString(names, rnd);

                        Carrier c = new Carrier(
                            i,
                            name,
                            IOConroller.RandomString(phoneNums, rnd),
                            IOConroller.RandomEmail(name, rnd),
                            i);
                        db.Carriers.AddRange(new List<Carrier> { c });

                    }
                    for (int i = 0; i < 1000; ++i)
                    {
                        DateTime[] dates = IOConroller.RandomDaysFunc(rnd);

                        Offer o = new Offer(
                            i,
                            dates[0],
                            IOConroller.RandomString(countries, rnd),
                            IOConroller.RandomString(countries, rnd),
                            dates[1],
                            i);
                        db.Offers.AddRange(new List<Offer> { o });
                    }
                        db.SaveChanges();

                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
