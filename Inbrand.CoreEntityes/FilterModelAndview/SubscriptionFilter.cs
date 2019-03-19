using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inbrand.CoreEntityes.FilterModelAndview
{
   public class SubscriptionFilter
    {
        public int Id { get; set; }
        public string domainName { get; set; }
        public string articleID { get; set; }
        public string tld { get; set; }
        public string customerID { get; set; }
        public string customerName { get; set; }
        public string price { get; set; }
        public DateTime? nextBillDate { get; set; }
        public DateTime? fromDate { get; set; }
        public DateTime? toDate { get; set; }
        
    }
}
