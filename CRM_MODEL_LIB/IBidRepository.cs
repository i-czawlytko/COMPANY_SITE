using System;
using System.Collections.Generic;
using System.Text;

namespace CRM_MODEL_LIB
{
    public interface IBidRepository
    {
        IEnumerable<Bid> Bids { get; }

        void UpdateStatus(Bid bid);
        void SaveBid(Bid bid);

        IEnumerable<Bid> GetConcreteDayBids(int ofset);

        IEnumerable<Bid> GetLastBids(int ofset);

        IEnumerable<Bid> GetDateRangeBids(DateTime left, DateTime right);
    }
}
