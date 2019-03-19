using Inbrand.Common.Helpers;
using Inbrand.CoreEntities;
using Inbrand.CoreEntityes.APIResponses;
using Inbrand.CoreEntityes.FilterModelAndview;
using Inbrand.CoreEntityes.Models;
using Inbrand.FrotNoxAPI.Interface;
using InbrandInterface.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
namespace ServiceLayer
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository invoiceRepository;
        public ArticleService(IArticleRepository _invoiceRepository)
        {
            this.invoiceRepository = _invoiceRepository;
        }
        public List<_Article> All(string articleid)
        {
            return invoiceRepository.All(articleid);
        }


        //public async Task<APIResponse> ValidateSubscriptionById(string articleid)
        //{
        //    APIResponse response = new APIResponse();
        //    try
        //    {
        //        response =  GetActiveArticles(articleid);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.StatusCode = StaticResource.failStatusCode;
        //        response.Message = ex.Message;
        //    }
        //    return response;
        //}
        public object GetActiveArticles(string articleid)
        {

            var URL = ConfigurationManager.AppSettings["fortnoxApiurl"];
           var FortnoxAPI_AccessToken = ConfigurationManager.AppSettings["AccessToken"];
           var FortnoxAPI_ClientSecret = ConfigurationManager.AppSettings["ClientSecret"];
            
            using (HttpClient _client = new HttpClient())
            {
                using (var httpRequestMessage = new HttpRequestMessage())
                {
                    httpRequestMessage.Method = HttpMethod.Get;
                    httpRequestMessage.RequestUri = new Uri(URL);
                    httpRequestMessage.Headers.Add("Access-Token", FortnoxAPI_AccessToken);
                    httpRequestMessage.Headers.Add("Client-Secret", FortnoxAPI_ClientSecret);
                   // httpRequestMessage.Headers.Add("Content-Type", contentTypeValue);
                    //httpRequestMessage.Headers.Add("Accept", contentTypeValue);
                    var response = _client.SendAsync(httpRequestMessage).Result;
                    var jsonResult = response.Content.ReadAsStringAsync().Result;
                     var jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<MasterFortNoxArticleSubset>(jsonResult);
                    //Newtonsoft.Json.JsonConvert.DeserializeObject<ServiceResult>(jsonResult);
                    //JavaScriptSerializer js = new JavaScriptSerializer();
                    //var json = js.Deserialize(jsonResult);
                    return invoiceRepository.ConvertToActiveArticleView(jsonResponse.Articles, articleid);
                    //return invoiceRepository.All(articleid);
                }
                
            }
        }

        public async Task<APIResponse> ValidateSubscriptionById(List<SubscriptionsModel> listsubscription)
        {
            APIResponse response = new APIResponse();
            try
            {
                response = await invoiceRepository.ValidateSubscriptionById(listsubscription);
            }
            catch (Exception ex)
            {
                response.StatusCode = StaticResource.failStatusCode;
                response.Message = ex.Message;
            }
            return response;
        }


        public List<_Article> GetMyActiveArticles(string articleid)
        {

            var URL = ConfigurationManager.AppSettings["fortnoxApiurl"];
            var FortnoxAPI_AccessToken = ConfigurationManager.AppSettings["AccessToken"];
            var FortnoxAPI_ClientSecret = ConfigurationManager.AppSettings["ClientSecret"];

            using (HttpClient _client = new HttpClient())
            {
                using (var httpRequestMessage = new HttpRequestMessage())
                {
                    httpRequestMessage.Method = HttpMethod.Get;
                    httpRequestMessage.RequestUri = new Uri(URL);
                    httpRequestMessage.Headers.Add("Access-Token", FortnoxAPI_AccessToken);
                    httpRequestMessage.Headers.Add("Client-Secret", FortnoxAPI_ClientSecret);
                    // httpRequestMessage.Headers.Add("Content-Type", contentTypeValue);
                    //httpRequestMessage.Headers.Add("Accept", contentTypeValue);
                    var response = _client.SendAsync(httpRequestMessage).Result;
                    var jsonResult = response.Content.ReadAsStringAsync().Result;
                    var jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<MasterFortNoxArticleSubset>(jsonResult);
                    //Newtonsoft.Json.JsonConvert.DeserializeObject<ServiceResult>(jsonResult);
                    //JavaScriptSerializer js = new JavaScriptSerializer();
                    //var json = js.Deserialize(jsonResult);
                    return invoiceRepository.MyConvertToActiveArticleView(jsonResponse.Articles, articleid);
                    //return make[0].;
                    //return invoiceRepository.All(articleid);
                }

            }
        }
    }
}
