using Inbrand.CoreEntityes.FilterModelAndview;
using Inbrand.FrotNoxAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary;
using Inbrand.CoreEntityes.APIResponses;
using Inbrand.CoreEntities;
using Inbrand.Common.Helpers;
using Inbrand.CoreEntityes.Models;
using System.Net;
using System.Configuration;

namespace Inbrand.FrotNoxAPI
{
    public class ArticleRepository : IArticleRepository
    {
        string FortnoxAPI_AccessToken = string.Empty;
        string FortnoxAPI_ClientSecret = string.Empty;
        public ArticleRepository()
        {
            FortnoxAPI_AccessToken = ConfigurationManager.AppSettings["AccessToken"];
            FortnoxAPI_ClientSecret = ConfigurationManager.AppSettings["ClientSecret"];
            ConnectionCredentials.AccessToken = FortnoxAPI_AccessToken;
            ConnectionCredentials.ClientSecret = FortnoxAPI_ClientSecret;
           
        }
        public List<_Article> All(string articleid)
        {
            var _articalConnector = new ArticleConnector();
            return ConvertToArticleView(_articalConnector.Find().ArticleSubset, articleid);
        }


        public List<_Article> ConvertToArticleView(List<ArticleSubset> articles, string articleid)
        {
            string hostName = Dns.GetHostName();
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            List<_Article> lst = new List<_Article>();
            if (articleid != null)
            {
                articles = articles.Where(x => x.ArticleNumber.Contains(articleid)).ToList();
            }
            foreach (var item in articles)
            {
                lst.Add(new _Article()
                {
                    ArticleNumber = item.ArticleNumber,
                    Description = item.Description,
                    DisposableQuantity = item.DisposableQuantity,
                    EAN = item.EAN,
                    Housework = item.Housework,
                    PurchasePrice = item.PurchasePrice,
                    QuantityInStock = item.QuantityInStock,
                    ReservedQuantity = item.ReservedQuantity,
                    SalesPrice = item.ReservedQuantity,
                    StockPlace = item.StockPlace,
                    StockValue = item.StockValue,
                    Unit = item.Unit,
                    VAT = item.VAT,
                    WebshopArticle = item.WebshopArticle
                });
            }
            return lst;
        }

        public object ConvertToActiveArticleView(List<Articless> articles, string articleid)
        {
            string hostName = Dns.GetHostName();
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            List<_Article> lst = new List<_Article>();
            if (articleid != null)
            {
                articles = articles.Where(x => x.ArticleNumber.Contains(articleid)).ToList();
            }
            foreach (var item in articles)
            {
                lst.Add(new _Article()
                {
                    ArticleNumber = item.ArticleNumber,
                    Description = item.Description,
                    DisposableQuantity = item.DisposableQuantity,
                    EAN = item.EAN,
                    Housework = item.Housework,
                    PurchasePrice = item.PurchasePrice,
                    QuantityInStock = item.QuantityInStock,
                    ReservedQuantity = item.ReservedQuantity,
                    SalesPrice = item.ReservedQuantity,
                    StockPlace = item.StockPlace,
                    StockValue = item.StockValue,
                    Unit = item.Unit,
                    VAT = item.VAT,
                    WebshopArticle = item.WebshopArticle
                });
            }
            return lst;
        }

        public async Task<APIResponse> ValidateSubscriptionById(List<SubscriptionsModel> listsubscription)
        {
            APIResponse response = new APIResponse();
            try
            {
                int count = 0;
                var _customer = new CustomerConnector();
                List<_Article> lst = new List<_Article>();
                var _articalConnector = new ArticleConnector();
                var articallist = _articalConnector.Find().ArticleSubset;
                var customerlist = _customer.Find().CustomerSubset;
                foreach (var list in listsubscription)
                {
                    var existarticle = articallist.Find(x => x.ArticleNumber == list.ArticleId);
                    if (existarticle != null)
                    {
                        var existcustomer = customerlist.Find(x => x.CustomerNumber == list.CustomerId);
                        if (existcustomer == null)
                        {
                            listsubscription[count].recordStatus = false;
                        }
                        else
                        {
                            listsubscription[count].recordStatus = true;
                        }
                    }
                    else
                    {
                        listsubscription[count].recordStatus = false;
                    }
                    count++;
                }
                response.data.SubscriptionsModelList = listsubscription;
                response.StatusCode = StaticResource.successStatusCode;
                response.Message = StaticResource.successmessage;
            }
            catch (Exception ex)
            {
                response.StatusCode = StaticResource.failStatusCode;
                response.Message = ex.Message;
            }
            return response;
        }


        public List<_Article> MyConvertToActiveArticleView(List<Articless> articles, string articleid)
        {
            string hostName = Dns.GetHostName();
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            List<_Article> lst = new List<_Article>();
            if (articleid != null)
            {
                //articles = articles.Where(x => x.ArticleNumber.Contains(articleid)).ToList();
                articles = articles.Where(x => x.ArticleNumber== articleid).ToList();
                //return articles[0].ArticleNumber;
            }
            // return articles[0].Description;
            foreach (var item in articles)
            {
                lst.Add(new _Article()
                {
                    ArticleNumber = item.ArticleNumber,
                    Description = item.Description,
                    DisposableQuantity = item.DisposableQuantity,
                    EAN = item.EAN,
                    Housework = item.Housework,
                    PurchasePrice = item.PurchasePrice,
                    QuantityInStock = item.QuantityInStock,
                    ReservedQuantity = item.ReservedQuantity,
                    SalesPrice = item.ReservedQuantity,
                    StockPlace = item.StockPlace,
                    StockValue = item.StockValue,
                    Unit = item.Unit,
                    VAT = item.VAT,
                    WebshopArticle = item.WebshopArticle
                });
            }
            return lst;
        }
    }
}
