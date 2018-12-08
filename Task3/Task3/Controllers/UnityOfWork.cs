using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Controllers
{
    public class UnitOfWork : IDisposable
    {
        private OfferContext db = new OfferContext();
        private OfferRepository offerRepository;

        public OfferRepository Offers
        {
            get
            {
                if (offerRepository == null)
                    offerRepository = new OfferRepository(db);
                return offerRepository;
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
