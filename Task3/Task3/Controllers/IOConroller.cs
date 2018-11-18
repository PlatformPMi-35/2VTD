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

            for (int i = 0; i < 1000; ++i)
            {
                Thread.Sleep(10);
                string name = RandomString(names);
                Offer o = new Offer(1000 + i, RandomDayFunc(), RandomString(countries), RandomString(countries), RandomDayFunc(),
                    (VehicleType)new Random().Next(0, 8), RandomDouble(0, 30), RandomDouble(0, 130), name, RandomString(PhoneNums), RandomEmail(name));
                oc.AddOffer(o);
            }

            SaveOffer(@"..\..\Resourses\Offres.dat", oc.GetOffers());
        }

        private static double RandomDouble(double min, double max)
        {
            Random random = new Random();
            return random.NextDouble() * (max - min) + min;
        }
        private static string RandomString(string[] strs)
        {
            Random rnd = new Random();
            int num = rnd.Next(0, strs.Length);
            return strs[num];
        }
        private static string RandomEmail(string fullName)
        {
            string lastName = fullName.Split(' ')[1];
            string[] ends = new string[] { "@yahoo.com", "@icloud.com", "@gmail.com", "@hotmail.com", "@ukr.net", "@msn.com" };
            string email = lastName + RandomString(ends);
            return email;
        }
        private static DateTime RandomDayFunc()
        {
            DateTime start = new DateTime(2018, 1, 1);
            Random gen = new Random();
            int range = ((TimeSpan)(DateTime.Today - start)).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}            