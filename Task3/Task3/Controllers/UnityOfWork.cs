namespace Task3.Controllers
{
    using System;

    /// <summary>
    /// Class that represents pattern Unity of Work.
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        /// <summary>
        /// Is instance disposed.
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Context of DB.
        /// </summary>
        private OfferContext db = new OfferContext();

        /// <summary>
        /// Repository of Offers.
        /// </summary>
        private OfferRepository offerRepository;

        /// <summary>
        /// Repository of Carrier.
        /// </summary>
        private CarrierRepository carrierRepository;

        /// <summary>
        /// Repository of Vehicle.
        /// </summary>
        private VehicleRepository vehicleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="connString">Connection string to DB.</param>
        public UnitOfWork(string connString = "DbConnection")
        {
            OfferContext db = new OfferContext(connString);
        }

        /// <summary>
        /// Gets OfferRepository.
        /// </summary>
        /// <value>All Offers.</value>
        public OfferRepository Offers
        {
            get
            {
                if (this.offerRepository == null)
                {
                    this.offerRepository = new OfferRepository(this.db);
                }

                return this.offerRepository;
            }
        }

        /// <summary>
        /// Gets CarrierRepository.
        /// </summary>
        /// <value>All Carriers.</value>
        public CarrierRepository Carriers
        {
            get
            {
                if (this.carrierRepository == null)
                {
                    this.carrierRepository = new CarrierRepository(this.db);
                }

                return this.carrierRepository;
            }
        }

        /// <summary>
        /// Gets VehicleRepository.
        /// </summary>
        /// <value>All Vehicles.</value>
        public VehicleRepository Vehicles
        {
            get
            {
                if (this.vehicleRepository == null)
                {
                    this.vehicleRepository = new VehicleRepository(this.db);
                }

                return this.vehicleRepository;
            }
        }

        /// <summary>
        /// Saves all changes.
        /// </summary>
        public void Save()
        {
            this.db.SaveChanges();
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        /// <param name="disposing">Is Disposed.</param>
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.db.Dispose();
                }

                this.disposed = true;
            }
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
