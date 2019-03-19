using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inbrand.CoreEntityes.Models
{
    public class SubscriptionsModel
    {
        public int DomainId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ArticleId { get; set; }
        public string Domain { get; set; }
        public string TLD { get; set; }
        public string Price { get; set; }
        public DateTime BillingDate { get; set; }
        public bool? recordStatus { get; set; }
    }

    public class MasterFortNoxArticleSubset
    {
        public MetaInformation MetaInformation { get; set; }
        public List<Articless> Articles { get; set; }
    }
    public class MetaInformation
    {
       
        public string @TotalResources { get; set; }
        public string @TotalPages { get; set; }
        public string @CurrentPage { get; set; }
       
    }
    public class Articless
    {
        //public ArticleSubset();

        public string ArticleNumber { get; set; }
        public string Description { get; set; }
        public string DisposableQuantity { get; set; }
        public string EAN { get; set; }
        public string Housework { get; set; }
        public string PurchasePrice { get; set; }
       
        public string SalesPrice { get; set; }
        public string QuantityInStock { get; set; }
        public string ReservedQuantity { get; set; }
        public string StockPlace { get; set; }
        public string StockValue { get; set; }
        public string Unit { get; set; }
        public string VAT { get; set; }
       
        public string @url { get; set; }
        public string WebshopArticle { get; set; }
    }

    public class SubscriptionIds
    {
        public int subscriptionId { get; set; }
      
    }

    public class MultipleDomain
    {
        public string Domains { get; set; }

    }

    public class TempInvoice
    {
        public string ArticleId { get; set; }
        public string DomainName { get; set; }
    }
}
