using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FortnoxAPILibrary;
using Inbrand.CoreEntityes.FilterModelAndview;
using Inbrand.CoreEntities;

namespace Inbrand.FrotNoxAPI.Interface
{
   public interface IInvoiceRepository
    {
        _Invoice Create(string customerNumber, List<Subscription> subscriptions, string deliveredQuntity, DateTime invoiceDate);
        _Invoice Update(string documentNumber, string freight);

    }
}
