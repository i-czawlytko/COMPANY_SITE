using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_MODEL_LIB;

namespace CRM_ASP.Models.ViewModels
{
    public class BidsListViewModel
    {
        public IEnumerable<Bid> Bids { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public IEnumerable<BidStatus> BidStatuses { get; set; }
        public FilterInfo FilterInfo { get; set; }
    }
}
