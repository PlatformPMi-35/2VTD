namespace Task3.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using Task3.Models;

    /// <summary>
    /// Class that represent Repository for <see cref="Carrier"/>.
    /// </summary>
    public class CarrierRepository : IRepository<Carrier>
    {
        /// <summary>
        /// Offer Context for DB.
        /// </summary>
        private OfferContext db;

        /// <summary>
        /// Initializes a new instance of the <see cref="CarrierRepository"/> class.
        /// </summary>
        /// <param name="context">Context for DB.</param>
        public CarrierRepository(OfferContext context)
        {
            this.db = context;
        }

        /// <summary>
        /// Adds <see cref="Carrier"/> to Context.
        /// </summary>
        /// <param name="carrier"><see cref="Carrier"/> to add.</param>
        public void Create(Carrier carrier)
        {
            this.db.Carriers.Add(carrier);
        }

        /// <summary>
        /// Deletes <see cref="Carrier"/> from Context by id.
        /// </summary>
        /// <param name="id">Id of <see cref="Carrier"/>.</param>
        public void Delete(int id)
        {
            Carrier carrier = this.db.Carriers.Find(id);
            if (carrier != null)
            {
                this.db.Carriers.Remove(carrier);
            }
        }

        /// <summary>
        /// Get <see cref="Carrier"/> by id.
        /// </summary>
        /// <param name="id">Id of <see cref="Carrier"/>.</param>
        /// <returns>Needed <see cref="Carrier"/>.</returns>
        public Carrier Get(int id)
        {
            return this.db.Carriers.Find(id);
        }

        /// <summary>
        /// Get All <see cref="Carrier"/>s.
        /// </summary>
        /// <returns>All <see cref="Carrier"/>s.</returns>
        public IEnumerable<Carrier> GetAll()
        {
            return this.db.Carriers;
        }

        /// <summary>
        /// Update <see cref="Carrier"/>.
        /// </summary>
        /// <param name="carrier">Updated <see cref="Carrier"/>.</param>
        public void Update(Carrier carrier)
        {
            this.db.Entry(carrier).State = EntityState.Modified;
        }
    }
}
