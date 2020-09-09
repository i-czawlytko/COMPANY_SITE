using System;
using System.Collections.Generic;
using System.Text;

namespace CRM_MODEL_LIB
{
    public class Bid
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string content { get; set; }
        public int BidStatusId { get; set; }
        public BidStatus status { get; set; }
        public System.DateTime create_date { get; set; }        
    }
}
