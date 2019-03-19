using Inbrand.CoreEntities;
using Inbrand.CoreEntityes;
using Inbrand.CoreEntityes.FilterModelAndview;
using Inbrand.FrotNoxAPI.Interface;
using InbrandInterface;
using InbrandInterface.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceLayer
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository invoiceRepository;
        private readonly IUnitOfWork unitOfWork;
        public InvoiceService(IInvoiceRepository _invoiceRepository, IUnitOfWork _unitOfWork)
        {
            this.invoiceRepository = _invoiceRepository;
            this.unitOfWork = _unitOfWork;
        }
       
        public List<Messages> Create(List<Subscription> subscriptions)
        {
            List<Messages> msg = new List<Messages>();
            var subscriptionForGenerate = unitOfWork.Subscriptions.SubscriptionsForGenerateInvoice(subscriptions.Select(x => x.Id).ToList(), DateTime.Now);
            List<string> customerIDs = subscriptionForGenerate.Select(x => x.customerID).Distinct().ToList();
            List<string> articleIDs = new List<string>();
            foreach (var custID in customerIDs)
            {
                var _subscriptions = subscriptionForGenerate.Where(x => x.customerID == custID).ToList();
                var invoice = invoiceRepository.Create(custID, _subscriptions, "1", DateTime.Now);
                if (string.IsNullOrEmpty(invoice.DocumentNumber))
                    msg.Add(new Messages() { success = false, msg = _subscriptions.FirstOrDefault().customerName + "'s invoice could not generate due to some invalid details." });
                else
                {   
                    foreach(var subs in _subscriptions)
                    {
                        subs.lastBillGenerateDate = subs.nextBillDate;
                        subs.nextBillDate = subs.nextBillDate.AddYears(1);
                        unitOfWork.Subscriptions.Update(subs);
                    }
                    unitOfWork.SaveChanges();
                    msg.Add(new Messages() { success = true, msg = _subscriptions.FirstOrDefault().customerName + "'s invoice generated successfully." });
                }
             }
            return msg;
        }
    }
}
