namespace Task3.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using Task3.Models;

    class IOConroller
    {
        public void SaveOffer(string path, Offer offer)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, offer);
            }
        }

        public void SaveOffer(string path, IEnumerable<Offer> offers)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, offers);
            }
        }

        public List<Offer> LoadOffer(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            List<Offer> offers = new List<Offer>();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                offers = (List<Offer>)formatter.Deserialize(fs);
            }
            return offers;
        }
    }
}            