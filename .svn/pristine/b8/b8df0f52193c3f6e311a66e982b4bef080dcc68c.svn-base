using Inbrand.CoreEntities;
using Inbrand.CoreEntityes.FilterModelAndview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InbrandInterface
{
   public interface ISubscriptionRepository : IRepository<Subscription>
    {
        List<Subscription> FilterBy(SubscriptionFilter subscription);
        List<Subscription> SubscriptionsForGenerateInvoice(List<int> subIDs, DateTime dat);
        bool CheckForDuplicate(string customerID, string articalID);
        bool CheckForDuplicate(string customerID, string articalID, int Id);
    }
}
