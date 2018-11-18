namespace Task3.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Threading;
    using Task3.Models;

    static class IOConroller
    {
        public static void SaveOffer(string path, Offer offer)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, offer);
            }
        }

        public static void SaveOffer(string path, IEnumerable<Offer> offers)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, offers);
            }
        }

        public static List<Offer> LoadOffer(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            List<Offer> offers = new List<Offer>();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                offers = (List<Offer>)formatter.Deserialize(fs);
            }
            return offers;
        }

        public static void GenerateRandomOffers()
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
                    (VehicleType)rnd.Next(0, 8), RandomDouble(0, 30, rnd), RandomDouble(0, 130, rnd), name, RandomString(PhoneNums, rnd), RandomEmail(name, rnd));
                oc.AddOffer(o);
            }

            SaveOffer(@"..\..\Resourses\Offres.dat", oc.GetOffers());
        }

        private static double RandomDouble(double min, double max, Random rnd)
        {
            return rnd.NextDouble() * (max - min) + min;
        }
        private static string RandomString(string[] strs, Random rnd)
        {
            int num = rnd.Next(0, strs.Length);
            return strs[num];
        }
        private static string RandomEmail(string fullName, Random rnd)
        {
            string lastName = fullName.Split(' ')[1];
            string[] ends = new string[] { "@yahoo.com", "@icloud.com", "@gmail.com", "@hotmail.com", "@ukr.net", "@msn.com" };
            string email = lastName + RandomString(ends, rnd);
            return email;
        }
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