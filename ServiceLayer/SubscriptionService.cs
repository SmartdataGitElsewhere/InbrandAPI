using Inbrand.Common.Helpers;
using Inbrand.CoreEntities;
using Inbrand.CoreEntityes.APIResponses;
using Inbrand.CoreEntityes.FilterModelAndview;
using Inbrand.CoreEntityes.Models;
using InbrandInterface;
using InbrandInterface.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubscriptionService(IUnitOfWork unitofwork)
        {
            this._unitOfWork = unitofwork;
        }
        public IQueryable<Subscription> GetAll()
        {
            return _unitOfWork.Subscriptions.GetAll().OrderByDescending(x => x.Id).Take(50).AsQueryable();
        }
        public List<Subscription> FilterBy(SubscriptionFilter subscription)
        {
            return _unitOfWork.Subscriptions.FilterBy(subscription);
        }
        public Subscription Find(int ID)
        {
            return _unitOfWork.Subscriptions.Get(ID);
        }
        public async Task<Subscription> FindAsync(int ID)
        {
            return await _unitOfWork.Subscriptions.GetAsync(ID);
        }
        public void Add(Subscription subscription)
        {
                _unitOfWork.Subscriptions.Add(subscription);
                _unitOfWork.SaveChanges();
        }
        public async Task<int> AddAsync(Subscription subscription)
        {
                _unitOfWork.Subscriptions.Add(subscription);
                return await _unitOfWork.SaveChangesAsync();
        }

        public void AddRange(List<Subscription> subscriptions)
        {
            //foreach(var subs in subscriptions)
            //{
            //    if (_unitOfWork.Subscriptions.CheckForDuplicate(subs.customerID, subs.articleID))
            //        throw new Exception("Duplicate record exist in subscription records.");
            //}
            _unitOfWork.Subscriptions.AddRange(subscriptions);
            _unitOfWork.SaveChanges();
        }
        public async Task<int> AddRangeAsync(List<Subscription> subscriptions)
        {
            //foreach (var subs in subscriptions)
            //{
            //    if (_unitOfWork.Subscriptions.CheckForDuplicate(subs.customerID, subs.articleID))
            //        throw new Exception("Duplicate record exist in subscription records.");
            //}
            _unitOfWork.Subscriptions.AddRange(subscriptions);
            return await _unitOfWork.SaveChangesAsync();
        }

        public void Update(Subscription subscription)
        {
            //if (_unitOfWork.Subscriptions.CheckForDuplicate(subscription.customerID, subscription.articleID, subscription.Id))
            //    throw new Exception("Article ID already exist for this customer ID.");
            var _subscription = _unitOfWork.Subscriptions.Get(subscription.Id);
            _subscription.articleID = subscription.articleID;
            _subscription.customerID = subscription.customerID;
            _subscription.customerName = subscription.customerName;
            _subscription.domainName = subscription.domainName;
            _subscription.nextBillDate = subscription.nextBillDate;
            _subscription.price = subscription.price;
            _subscription.tld = subscription.tld;
            _unitOfWork.SaveChanges();
        }
        public async Task<int> UpdateAsync(Subscription subscription)
        {
            //if (_unitOfWork.Subscriptions.CheckForDuplicate(subscription.customerID, subscription.articleID, subscription.Id))
            //    throw new Exception("Article ID already exist for this customer ID.");
            var _subscription = _unitOfWork.Subscriptions.Get(subscription.Id);
            _subscription.articleID = subscription.articleID;
            _subscription.customerID = subscription.customerID;
            _subscription.customerName = subscription.customerName;
            _subscription.domainName = subscription.domainName;
            _subscription.nextBillDate = subscription.nextBillDate;
            _subscription.price = subscription.price;
            _subscription.tld = subscription.tld;
            return await _unitOfWork.SaveChangesAsync();
        }
        public void Delete(int ID)
        {
            var subscription = _unitOfWork.Subscriptions.Get(ID);
            _unitOfWork.Subscriptions.Remove(subscription);
            _unitOfWork.SaveChanges();
        }
        public async Task<int> DeleteAsync(int ID)
        {
            var subscription = _unitOfWork.Subscriptions.Get(ID);
            _unitOfWork.Subscriptions.Remove(subscription);
            return await _unitOfWork.SaveChangesAsync();
        }
        public bool Exists(int ID)
        {
            return _unitOfWork.Subscriptions.Get(ID) == null ? false : true;
        }

        public async Task<APIResponse> DeleteMultiple(List<SubscriptionIds> listsubscription)
        {
            APIResponse response = new APIResponse();
            try
            {
                foreach (SubscriptionIds _subscriptionid in listsubscription)
                {
                    var subscription = _unitOfWork.Subscriptions.Get(_subscriptionid.subscriptionId);
                    if (subscription != null)
                    {
                        _unitOfWork.Subscriptions.Remove(subscription);
                        _unitOfWork.SaveChanges();
                    }
                   
                }
                }
            catch (Exception ex)
            {
                response.StatusCode = StaticResource.failStatusCode;
                response.Message = ex.Message;
            }
            return response;
        }

        public object GetCustomerProduct(string domainname)
        {

            var subscription = _unitOfWork.Subscriptions.Find(x=>x.domainName== domainname).FirstOrDefault();
            if (subscription != null)
            {
                return subscription;
            }
           
            return subscription;
        }

        public object SearchMultipleDomain(List<string> multipledomains)
        {
           
            List<string>existingdomain= _unitOfWork.Subscriptions.GetAll().Select(x => x.domainName).ToList();
           

            var a = existingdomain;
            var b = a.Select(x => x == null ? null : x.Trim()).ToArray();
            List<string> multipledomins = multipledomains;
            
            IEnumerable<string> aOnlyNumbers = multipledomins.Except(b);
            return aOnlyNumbers;

     

        }

        public object SearchMultipleDomainList(List<string> multipledomains)
        {
            IList<Subscription> claimCallBackStatuses = null;
            claimCallBackStatuses = new List<Subscription>();
            List<Subscription> result = new List<Subscription>();
            foreach(var j in multipledomains)
            {
                claimCallBackStatuses = _unitOfWork.Subscriptions.GetAll().Where(x => x.domainName.Trim() == j).ToList();
                result.AddRange(claimCallBackStatuses);
            }         
            return result;            
        }

        
    }
}
