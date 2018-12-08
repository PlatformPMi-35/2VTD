using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Models;

namespace Task3.Controllers
{
    public class OfferContext : DbContext
    {
        public OfferContext()
            : base("DbConnection")
        { }

        public DbSet<Offer> Offers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
    }
}
