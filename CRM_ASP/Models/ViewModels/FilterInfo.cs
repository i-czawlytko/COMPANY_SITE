using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_ASP.Models.ViewModels
{
    public class FilterInfo
    {
        public int DateOfset { get; set; }
        public int DaysLeft { get; set; }
        public DateTime LeftDate { get; set; }

        public DateTime RightDate { get; set; }

        public int? BidStatusId { get; set; }
    }
}
