namespace Task3.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using Task3.Models;

    /// <summary>
    /// This class represent the list of  <see cref="Carrier"/>.
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
        /// This function deletes <see cref="Carrier"/> from Context by id.
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
        /// This function gets <see cref="Carrier"/> by id.
        /// </summary>
        /// <param name="id">Id of <see cref="Carrier"/>.</param>
        /// <returns>Needed <see cref="Carrier"/>.</returns>
        public Carrier Get(int id)
        {
            return this.db.Carriers.Find(id);
        }

        /// <summary>
        /// This function gets All <see cref="Carrier"/>s from Context.
        /// </summary>
        /// <returns>All <see cref="Carrier"/>s.</returns>
        public IEnumerable<Carrier> GetAll()
        {
            return this.db.Carriers;
        }

        /// <summary>
        /// This function updates <see cref="Carrier"/> state.
        /// </summary>
        /// <param name="carrier">Updated <see cref="Carrier"/>.</param>
        public void Update(Carrier carrier)
        {
            this.db.Entry(carrier).State = EntityState.Modified;
        }
    }
}
