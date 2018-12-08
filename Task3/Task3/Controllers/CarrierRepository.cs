using System.Collections.Generic;
using System.Data.Entity;
using Task3.Models;

namespace Task3.Controllers
{
    class CarrierRepository : IRepository<Carrier>
    {
        private OfferContext db;

        public CarrierRepository(OfferContext context)
        {
            this.db = context;
        }

        public void Create(Carrier carrier)
        {
            db.Carriers.Add(carrier);
        }

        public void Delete(int id)
        {
            Carrier carrier = db.Carriers.Find(id);
            if (carrier != null)
                db.Carriers.Remove(carrier);
        }

        public Carrier Get(int id)
        {
            return db.Carriers.Find(id);
        }

        public IEnumerable<Carrier> GetAll()
        {
            return db.Carriers;
        }

        public void Update(Carrier carrier)
        {
            db.Entry(carrier).State = EntityState.Modified;
        }
    }
}
