namespace Task3.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Task3.Models;

    /// <summary>
    /// Class that represents Repository of <see cref="Offer"/>s.
    /// </summary>
    public class OfferRepository : IRepository<Offer>
    {
        /// <summary>
        /// Offer Context for DB.
        /// </summary>
        private OfferContext db;

        /// <summary>
        /// Initializes a new instance of the <see cref="OfferRepository"/> class.
        /// </summary>
        /// <param name="context">Context for DB.</param>
        public OfferRepository(OfferContext context)
        {
            this.db = context;
        }

        /// <summary>
        /// Adds <see cref="Offer"/> to Context.
        /// </summary>
        /// <param name="offer"><see cref="Offer"/> to add.</param>
        public void Create(Offer offer)
        {
            this.db.Offers.Add(offer);
        }

        /// <summary>
        /// Deletes <see cref="Offer"/> from Context by id.
        /// </summary>
        /// <param name="id">Id of <see cref="Offer"/>.</param>
        public void Delete(int id)
        {
            Offer offer = this.db.Offers.Find(id);
            if (offer != null)
            {
                this.db.Offers.Remove(offer);
            }
        }

        /// <summary>
        /// Get <see cref="Offer"/> by id.
        /// </summary>
        /// <param name="id">Id of <see cref="Offer"/>.</param>
        /// <returns>Needed <see cref="Offer"/>.</returns>
        public Offer Get(int id)
        {
            return this.db.Offers.Find(id);
        }

        /// <summary>
        /// Get All <see cref="Offer"/>s.
        /// </summary>
        /// <returns>All <see cref="Offer"/>s.</returns>
        public IEnumerable<Offer> GetAll()
        {
            List<Offer> res = new List<Offer>();
            var v = this.db.Offers.ToList();
            foreach (var item in v)
            {
                Offer offer = item;
                offer.Carrier = this.db.Carriers.Where(p => p.CarrierId == offer.OfferId).ToArray().Last();
                offer.Carrier.Vehicle = this.db.Vehicles.Where(p => p.VehicleId == offer.Carrier.VehicleId).ToArray().Last();
                res.Add(offer);
            }

            return res;
        }

        /// <summary>
        /// Update <see cref="Offer"/>.
        /// </summary>
        /// <param name="offer">Updated <see cref="Offer"/>.</param>
        public void Update(Offer offer)
        {
            this.db.Entry(offer).State = EntityState.Modified;
        }
    }
}
