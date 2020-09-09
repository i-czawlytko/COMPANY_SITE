using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_MODEL_LIB;

namespace CRM_ASP.Models
{
    public class EFOfferRepository : IOfferRepository
    {
        private AppDbContext context;

        public EFOfferRepository(AppDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Offer> Offers => context.Offers;

        public void SaveOffer(Offer offer)
        {
            context.Offers.Add(offer);
            context.SaveChanges();
        }
    }
}
