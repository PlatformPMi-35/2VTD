namespace Task3.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    /// <summary>
    /// Class Configuration of DB.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<Task3.Controllers.OfferContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "Task3.Controllers.OfferContext";
        }

        /// <summary>
        /// Creates Seed.
        /// </summary>
        /// <param name="context">Context of DB.</param>
        protected override void Seed(Task3.Controllers.OfferContext context)
        {
            ////  This method will be called after migrating to the latest version.

            ////  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            ////  to avoid creating duplicate seed data.
        }
    }
}
