using System.Collections.Generic;
using System.Data.Entity;
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
            return db.Offers;
        }

        public void Update(Offer offer)
        {
            db.Entry(offer).State = EntityState.Modified;
        }
    }
}
