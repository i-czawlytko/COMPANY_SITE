using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_MODEL_LIB;

namespace CRM_ASP.Models
{
    public class EFStatuses
    {
        private AppDbContext context;

        public EFStatuses(AppDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<BidStatus> Statuses => context.Statuses;

    }
}
