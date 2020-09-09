using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_MODEL_LIB;
using Microsoft.EntityFrameworkCore;

namespace CRM_ASP.Models
{
    public class EFBidRepository : IBidRepository
    {
        private AppDbContext context;

        public EFBidRepository(AppDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Bid> Bids => context.Bids.Include(p => p.status).ToArray();

        public void UpdateStatus(Bid bid)
        {
            Bid b = context.Bids.Find(bid.id);
            b.BidStatusId = bid.BidStatusId;
            context.SaveChanges();
        }


        public void SaveBid(Bid bid)
        {
            context.Bids.Add(bid);
            context.SaveChanges();
        }

        public IEnumerable<Bid> GetConcreteDayBids(int ofset)
        {
            return Bids.Where(b => b.create_date.ToShortDateString() == DateTime.Today.AddDays(ofset*(-1)).ToShortDateString());
        }

        public IEnumerable<Bid> GetLastBids(int days_left)
        {
            return Bids.Where(b => b.create_date >= DateTime.Today.AddDays(days_left*(-1)));
        }

        public IEnumerable<Bid> GetDateRangeBids(DateTime left, DateTime right)
        {
            return Bids.Where(b => b.create_date >= left && b.create_date <= right);
        }
    }
}
