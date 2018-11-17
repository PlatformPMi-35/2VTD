namespace Task3.Controllers
{
    using System.Collections.Generic;
    using Task3.Models;

    class OfferController
    {
        List<Offer> offers;

        public OfferController(List<Offer> lo)
        {
            offers = lo;
        }
        public OfferController() : this(new List<Offer>()) { }

        public void AddOffers(Offer offer)
        {
            offers.Add(offer);
        }

        public void RemoveOffers(Offer offer)
        {
            offers.Remove(offer);
        }

        public List<Offer> GetOffers()
        {
            return offers;
        }
        public List<Offer> GetOffers(Filter filter)
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

                if(filter.Type != null)
                {
                    if(o.VehicleInfo.Type != filter.Type)
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

                if (filter.MinVolume != null)
                {
                    if (o.VehicleInfo.Volume < filter.MinVolume)
                    {
                        continue;
                    }
                }
                if (filter.MaxVolume != null)
                {
                    if (o.VehicleInfo.Volume > filter.MaxVolume)
                    {
                        continue;
                    }
                }

                res.Add(o);
            }

            return res;
        }
    }
}
