using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inbrand.FrotNoxAPI.Interface;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary;
using Inbrand.CoreEntityes.FilterModelAndview;
using Inbrand.CoreEntities;
using System.Configuration;
using InbrandInterface.ServiceInterface;

namespace Inbrand.FrotNoxAPI
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly IArticleService myinvoiceRepository;
        string FortnoxAPI_AccessToken = string.Empty;
        string FortnoxAPI_ClientSecret = string.Empty;
        public InvoiceRepository(IArticleService _myinvoiceRepository)
        {
            FortnoxAPI_AccessToken = ConfigurationManager.AppSettings["AccessToken"];
            FortnoxAPI_ClientSecret = ConfigurationManager.AppSettings["ClientSecret"];
            ConnectionCredentials.AccessToken = FortnoxAPI_AccessToken;
           ConnectionCredentials.ClientSecret = FortnoxAPI_ClientSecret;
            this.myinvoiceRepository = _myinvoiceRepository;
        }
        public _Invoice Create(string customerNumber, List<Subscription> subscriptions, string deliveredQuntity, DateTime invoiceDate)
        {
            try
            {
                InvoiceConnector _invoiceConnector = new InvoiceConnector();
                List<InvoiceRow> row = new List<InvoiceRow>();
                //foreach(var j in subscriptions)
                //{
                //    List<_Article> mylist = myinvoiceRepository.GetMyActiveArticles(j.articleID);
                //}
               // var take = myinvoiceRepository.GetMyActiveArticles(subscriptions[0].articleID);
                

                foreach (var subs in subscriptions)
                {
                    List<_Article> mylist = myinvoiceRepository.GetMyActiveArticles(subs.articleID);
                    foreach (var i in mylist)
                    {
                       var tmake = i.Description;
                        //var kate = i.ArticleNumber;
                        var make = tmake + "   " + subs.domainName;
                        row.Add(new InvoiceRow() {Price=subs.price, ArticleNumber = subs.articleID, Description= make, DeliveredQuantity = deliveredQuntity });
                        //row.Add(new InvoiceRow() { Price = subs.price, ArticleNumber = kate, Description = make, DeliveredQuantity = deliveredQuntity });
                    }
                    
                    
                    //row.Add(new InvoiceRow() { Price = subs.price, ArticleNumber = subs.articleID, DeliveredQuantity = deliveredQuntity });
                    
                }
                string finalString = String.Empty;
                var invoice = _invoiceConnector.Create(new Invoice() { CustomerNumber = customerNumber, InvoiceRows = row });
                foreach (var i in invoice.InvoiceRows)
                {
                    foreach (var j in subscriptions)
                    {
                        if (i.ArticleNumber == j.articleID)
                        {
                            finalString = "<" + i.Description + ">" + "" + "<" + j.domainName + ">";
                            i.Description = finalString;
                        }
                    }
                }

                return ConvertTo_InviewView(invoice);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public _Invoice Update(string documentNumber, string freight)
        {

            return new _Invoice();
        }


        private _Invoice ConvertTo_InviewView(Invoice invoice)
        {
            return new _Invoice()
            {
                Address1 = invoice.Address1,
                Address2 = invoice.Address2,
                AdministrationFee = invoice.AdministrationFee,
                AdministrationFeeVAT = invoice.AdministrationFeeVAT,
                 Balance = invoice.Balance,
                //Balance = invoice.InvoiceRows[0].Price,
                BasisTaxReduction = invoice.BasisTaxReduction,
                Booked = invoice.Booked,
                Cancelled = invoice.Cancelled,
                City = invoice.City,
                Comments = invoice.Comments,
                ContractReference = invoice.ContractReference,
                ContributionPercent = invoice.ContributionPercent,
                ContributionValue = invoice.ContributionValue,
                CostCenter = invoice.CostCenter,
                Country = invoice.Country,
                Credit = invoice.Credit,
                CreditInvoiceReference = invoice.CreditInvoiceReference,
                Currency = invoice.Currency,
                CurrencyRate = invoice.CurrencyRate,
                CurrencyUnit = invoice.CurrencyUnit,
                CustomerName = invoice.CustomerName,
                CustomerNumber = invoice.CustomerNumber,
                DeliveryAddress1 = invoice.DeliveryAddress1,
                DeliveryAddress2 = invoice.DeliveryAddress2,
                DeliveryCity = invoice.DeliveryCity,
                DeliveryCountry = invoice.DeliveryCountry,
                DeliveryDate = invoice.DeliveryDate,
                DeliveryName = invoice.DeliveryName,
                DeliveryZipCode = invoice.DeliveryZipCode,
                DocumentNumber = invoice.DocumentNumber,
                DueDate = invoice.DueDate,
                EUQuarterlyReport = invoice.EUQuarterlyReport,
                ExternalInvoiceReference1 = invoice.ExternalInvoiceReference1,
                ExternalInvoiceReference2 = invoice.ExternalInvoiceReference2,
                Freight = invoice.Freight,
                FreightVAT = invoice.FreightVAT,
                ZipCode = invoice.ZipCode,
                Gross = invoice.Gross,
                InvoiceDate = invoice.InvoiceDate,
                Net = invoice.Net,
                Phone1 = invoice.Phone1,
                Phone2 = invoice.Phone2
            };
        }
    }
}
