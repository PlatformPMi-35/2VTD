using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Controllers
{
    public class UnitOfWork : IDisposable
    {
        public UnitOfWork(string connString = "DbConnection")
        {
            OfferContext db = new OfferContext(connString);
        }

        private OfferContext db = new OfferContext();
        private OfferRepository offerRepository;
        private CarrierRepository carrierRepository;
        private VehicleRepository vehicleRepository;

        public OfferRepository Offers
        {
            get
            {
                if (offerRepository == null)
                    offerRepository = new OfferRepository(db);
                return offerRepository;
            }
        }

        public CarrierRepository Carriers
        {
            get
            {
                if (carrierRepository == null)
                    carrierRepository = new CarrierRepository(db);
                return carrierRepository;
            }
        }

        public VehicleRepository Vehicles
        {
            get
            {
                if (vehicleRepository == null)
                    vehicleRepository = new VehicleRepository(db);
                return vehicleRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
