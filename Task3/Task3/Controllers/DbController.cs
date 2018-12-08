using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Models;

namespace Task3.Controllers
{
    class DbController
    {
        /// <summary>
        /// Saves offers to database
        /// </summary>
        /// <param name="offer"><see cref="IEnumerabl{Offer}"/> to save.</param>
        public static void SaveOffers(List<Offer> offers)
        {
            try
            {
                using (OfferContext db = new OfferContext())
                {
                    foreach (Offer offer in offers)
                    {
                        db.Offers.Add(offer);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Load offers from database
        /// </summary>
        /// <returns><see cref="List{Offer}"/> of <see cref="Offer"/>s</returns>
        public static List<Offer> LoadOffers()
        {
            try
            {
                using (OfferContext db = new OfferContext())
                {
                    return db.Offers.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
