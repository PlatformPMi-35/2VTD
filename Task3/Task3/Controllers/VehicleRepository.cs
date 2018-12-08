using System.Collections.Generic;
using System.Data.Entity;
using Task3.Models;

namespace Task3.Controllers
{
    class VehicleRepository : IRepository<Vehicle>
    {
        private OfferContext db;

        public VehicleRepository(OfferContext context)
        {
            this.db = context;
        }

        public void Create(Vehicle vehicle)
        {
            db.Vehicles.Add(vehicle);
        }

        public void Delete(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle != null)
                db.Vehicles.Remove(vehicle);
        }

        public Vehicle Get(int id)
        {
            return db.Vehicles.Find(id);
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return db.Vehicles;
        }

        public void Update(Vehicle vehicle)
        {
            db.Entry(vehicle).State = EntityState.Modified;
        }
    }
}
