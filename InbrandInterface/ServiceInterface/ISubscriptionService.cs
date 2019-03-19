using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inbrand.CoreEntities;
using Inbrand.CoreEntityes.APIResponses;
using Inbrand.CoreEntityes.FilterModelAndview;
using Inbrand.CoreEntityes.Models;

namespace InbrandInterface.ServiceInterface
{
   public interface ISubscriptionService
    {
        IQueryable<Subscription> GetAll();
        List<Subscription> FilterBy(SubscriptionFilter subscription);
        Subscription Find(int ID);
        Task<Subscription> FindAsync(int ID);
        void Add(Subscription subscription);
        Task<int> AddAsync(Subscription subscription);
        void AddRange(List<Subscription> subscriptions);
        Task<int> AddRangeAsync(List<Subscription> subscriptions);
        void Update(Subscription subscription);
        Task<int> UpdateAsync(Subscription subscription);
        void Delete(int ID);
        Task<int> DeleteAsync(int ID);
        bool Exists(int ID);
       Task<APIResponse> DeleteMultiple(List<SubscriptionIds> listsubscription);
        object GetCustomerProduct(string domainname);
        object SearchMultipleDomain(List<string> multipledomains);
        object SearchMultipleDomainList(List<string> multipledomains);
    }
}
