namespace Task3.Controllers
{
    using System.Data.Entity;
    using Task3.Models;

    /// <summary>
    /// Class that represents context of DB.
    /// </summary>
    public class OfferContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OfferContext"/> class.
        /// </summary>
        /// <param name="connString">Connection string to DB.</param>
        public OfferContext(string connString = "DbConnection") : base(connString)
        {
        }

        /// <summary>
        /// Gets or sets Offers.
        /// </summary>
        /// <value>All <see cref="DbSet{Offers}"/> in DB.</value>
        public DbSet<Offer> Offers { get; set; }

        /// <summary>
        /// Gets or sets Vehicles.
        /// </summary>
        /// <value>All <see cref="DbSet{Vehicles}"/> in DB.</value>
        public DbSet<Vehicle> Vehicles { get; set; }

        /// <summary>
        /// Gets or sets Carriers.
        /// </summary>
        /// <value>All <see cref="DbSet{Carriers}"/> in DB.</value>
        public DbSet<Carrier> Carriers { get; set; }
    }
}
