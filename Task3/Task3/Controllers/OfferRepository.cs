using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Task3.Models;

namespace Task3.Controllers
{
    public class OfferRepository : IRepository<Offer>
    {
        private OfferContext db;

        public OfferRepository(OfferContext context)
        {
            this.db = context;
        }

        public void Create(Offer offer)
        {
            db.Offers.Add(offer);
        }

        public void Delete(int id)
        {
            Offer offer = db.Offers.Find(id);
            if (offer != null)
                db.Offers.Remove(offer);
        }

        public Offer Get(int id)
        {
            return db.Offers.Find(id);
        }

        public IEnumerable<Offer> GetAll()
        {
            List<Offer> res = new List<Offer>();
            var v = db.Offers.ToList();
            foreach (var item in v)
            {
                Offer offer = item;
                db.Carriers.Where(p => p.CarrierId == offer.OfferId).Load();
                offer.Carrier = db.Carriers.FirstOrDefault();
                db.Vehicles.Where(p => p.VehicleId == offer.Carrier.VehicleId).Load();
                offer.Carrier.Vehicle = db.Vehicles.FirstOrDefault();
                res.Add(offer);
            }

            return res;
        }

        public void Update(Offer offer)
        {
            db.Entry(offer).State = EntityState.Modified;
        }
    }
}
