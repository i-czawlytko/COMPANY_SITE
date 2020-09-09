using System;
using System.Collections.Generic;
using System.Text;

namespace CRM_MODEL_LIB
{
    public interface IOfferRepository
    {
        IEnumerable<Offer> Offers { get; }
        void SaveOffer(Offer offer);
    }
}
