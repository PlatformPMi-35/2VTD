namespace Task3.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using Task3.Models;

    /// <summary>
    /// Class that represents Repository of <see cref="Vehicle"/>s.
    /// </summary>
    public class VehicleRepository : IRepository<Vehicle>
    {
        /// <summary>
        /// Offer Context for DB.
        /// </summary>
        private OfferContext db;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleRepository"/> class.
        /// </summary>
        /// <param name="context">Context for DB.</param>
        public VehicleRepository(OfferContext context)
        {
            this.db = context;
        }

        /// <summary>
        /// Adds <see cref="Vehicle"/> to Context.
        /// </summary>
        /// <param name="vehicle"><see cref="Vehicle"/> to add.</param>
        public void Create(Vehicle vehicle)
        {
            this.db.Vehicles.Add(vehicle);
        }

        /// <summary>
        /// Deletes <see cref="Vehicle"/> from Context by id.
        /// </summary>
        /// <param name="id">Id of <see cref="Vehicle"/>.</param>
        public void Delete(int id)
        {
            Vehicle vehicle = this.db.Vehicles.Find(id);
            if (vehicle != null)
            {
                this.db.Vehicles.Remove(vehicle);
            }
        }

        /// <summary>
        /// Get <see cref="Vehicle"/> by id.
        /// </summary>
        /// <param name="id">Id of <see cref="Vehicle"/>.</param>
        /// <returns>Needed <see cref="Vehicle"/>.</returns>
        public Vehicle Get(int id)
        {
            return this.db.Vehicles.Find(id);
        }

        /// <summary>
        /// Get All <see cref="Vehicle"/>s.
        /// </summary>
        /// <returns>All <see cref="Vehicle"/>s.</returns>
        public IEnumerable<Vehicle> GetAll()
        {
            return this.db.Vehicles;
        }

        /// <summary>
        /// Update <see cref="Vehicle"/>.
        /// </summary>
        /// <param name="vehicle">Updated <see cref="Vehicle"/>.</param>
        public void Update(Vehicle vehicle)
        {
            this.db.Entry(vehicle).State = EntityState.Modified;
        }
    }
}
