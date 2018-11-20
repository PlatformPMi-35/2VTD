namespace Task3.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using Task3.Models;

    /// <summary>
    /// Manage offers file input and output
    /// </summary>
    static class IOConroller
    {
        /// <summary>
        /// Saves offer to binary file
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="offer"><see cref="Offer"/> to save.</param>
        public static void SaveOffer(string path, Offer offer)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, offer);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Saves offers to binary file
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="offer"><see cref="IEnumerabl{Offer}"/> to save.</param>
        public static void SaveOffer(string path, IEnumerable<Offer> offers)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, offers);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Load offers from binary file
        /// </summary>
        /// <param name="path">>Path to file</param>
        /// <returns><see cref="List{Offer}"/> of <see cref="Offer"/>s</returns>
        public static List<Offer> LoadOffer(string path)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                List<Offer> offers = new List<Offer>();
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    offers = (List<Offer>)formatter.Deserialize(fs);
                }
                return offers;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Generate binary file of random offers
        /// </summary>
        public static void GenerateRandomOffers()
        {
            try
            {
                string[] countries = File.ReadAllText(@"..\..\Resourses\Countries.txt").Split('\n');
                string[] names = File.ReadAllText(@"..\..\Resourses\Names.txt").Split('\n');
                string[] PhoneNums = File.ReadAllText(@"..\..\Resourses\PhoneNumbers.txt").Split('\n');

                OfferController oc = new OfferController();
                Random rnd = new Random();
                for (int i = 0; i < 1000; ++i)
                {
                    DateTime[] dates = RandomDaysFunc(rnd);
                    //while (date2 >= date1)
                    //{
                    //    date2 = RandomDayFunc(rnd);
                    //}
                    string name = RandomString(names, rnd);

                    Offer o = new Offer(1000 + i, dates[0], RandomString(countries, rnd), RandomString(countries, rnd), dates[1],
                        (VehicleType)rnd.Next(0, 8), RandomDouble(0.1, 30, rnd), name, RandomString(PhoneNums, rnd), RandomEmail(name, rnd));
                    oc.AddOffer(o);
                }

                SaveOffer(@"..\..\Resourses\Offres.dat", oc.GetOffers());
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Generate random double value
        /// </summary>
        /// <param name="min">min double</param>
        /// <param name="max"> max double</param>
        /// <param name="rnd"><see cref="Random"/> object to generate value</param>
        /// <returns>Random <see cref="double"/></returns>
        private static double RandomDouble(double min, double max, Random rnd)
        {
            return rnd.NextDouble() * (max - min) + min;
        }

        /// <summary>
        /// Get random string from array of strings
        /// </summary>
        /// <param name="strs">array of strings</param>
        /// <param name="rnd"><see cref="Random"/> object to make it random</param>
        /// <returns>Random <see cref="string"/></returns>
        private static string RandomString(string[] strs, Random rnd)
        {
            int num = rnd.Next(0, strs.Length);
            return strs[num];
        }

        /// <summary>
        /// Get random email for specific name
        /// </summary>
        /// <param name="fullName">Full name</param>
        /// <param name="rnd"><see cref="Random"/> object to make it random</param>
        /// <returns><see cref="string"/> which represent random Email</returns>
        private static string RandomEmail(string fullName, Random rnd)
        {
            string lastName = fullName.Split(' ')[1];
            string[] ends = new string[] { "@yahoo.com", "@icloud.com", "@gmail.com", "@hotmail.com", "@ukr.net", "@msn.com" };
            string email = lastName + RandomString(ends, rnd);
            return email;
        }

        /// <summary>
        /// Generate 2 random dates, where second date later then first
        /// </summary>
        /// <param name="rnd"><see cref="Random"/> object to make it random</param>
        /// <returns><see cref="DateTime[]"/> of <see cref="DateTime"/>s</returns>
        private static DateTime[] RandomDaysFunc(Random rnd)
        {
            DateTime start = new DateTime(2018, 1, 1);
            int range = ((TimeSpan)(DateTime.Today - start)).Days;
            DateTime[] dates = new DateTime[2];
            dates[0] = start.AddDays(rnd.Next(range));
            dates[1] = dates[0].AddDays(rnd.Next(2, 20));
            return dates;
        }
    }
}            