namespace Task3.Controllers
{
    using System;
    using System.Collections.Generic;
    using Task3.Models;

    /// <summary>
    /// Store and manage offers
    /// </summary>
    class OfferController
    {
        /// <summary>
        /// <see cref="List{Offer}"/> of <see cref="Offer"/>s
        /// </summary>
        List<Offer> offers;

        /// <summary>
        /// Initializes a new instance of the <see cref="OfferController" /> class.
        /// </summary>
        /// <param name="lo"><see cref="List{Offer}"/> of <see cref="Offer"/>s</param>
        public OfferController(List<Offer> lo)
        {
            offers = lo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OfferController" /> class.
        /// </summary>
        public OfferController() : this(new List<Offer>()) { }

        /// <summary>
        /// Add offer
        /// </summary>
        /// <param name="offer">Offer</param>
        public void AddOffer(Offer offer)
        {
            offers.Add(offer);
        }

        /// <summary>
        /// Remove offer
        /// </summary>
        /// <param name="offer">Offer</param>
        public void RemoveOffer(Offer offer)
        {
            offers.Remove(offer);
        }

        /// <summary>
        /// Get list of offers
        /// </summary>
        /// <returns><see cref="List{Offer}"/> of <see cref="Offer"/>s</returns>
        public List<Offer> GetOffers()
        {
            return offers;
        }

        /// <summary>
        /// Get list of offers with aplied filter
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <returns><see cref="List{Offer}"/> of <see cref="Offer"/>s</returns>
        public List<Offer> GetOffers(Filter filter)
        {
            try
            {
                List<Offer> res = new List<Offer>();

                foreach (Offer o in offers)
                {
                    if (filter.MinDateOfPosting != null)
                    {
                        if (o.DateOfPosting < filter.MinDateOfPosting)
                        {
                            continue;
                        }
                    }
                    if (filter.MaxDateOfPosting != null)
                    {
                        if (o.DateOfPosting > filter.MaxDateOfPosting)
                        {
                            continue;
                        }
                    }

                    if (filter.From != null)
                    {
                        if (o.From != filter.From)
                        {
                            continue;
                        }
                    }
                    if (filter.To != null)
                    {
                        if (o.To != filter.To)
                        {
                            continue;
                        }
                    }

                    if (filter.MinDateOfLoading != null)
                    {
                        if (o.DateOfLoading < filter.MinDateOfLoading)
                        {
                            continue;
                        }
                    }
                    if (filter.MaxDateOfLoading != null)
                    {
                        if (o.DateOfLoading > filter.MaxDateOfLoading)
                        {
                            continue;
                        }
                    }

                    if (filter.Type != null)
                    {
                        if (o.VehicleInfo.Type != filter.Type)
                        {
                            continue;
                        }
                    }

                    if (filter.MinWeight != null)
                    {
                        if (o.VehicleInfo.Weight < filter.MinWeight)
                        {
                            continue;
                        }
                    }
                    if (filter.MaxWeight != null)
                    {
                        if (o.VehicleInfo.Weight > filter.MaxWeight)
                        {
                            continue;
                        }
                    }

                    res.Add(o);
                }

                return res;
            }
            catch (Exception)
            {
                throw;
            }
        } 
    }
}
