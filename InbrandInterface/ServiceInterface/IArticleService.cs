using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inbrand.CoreEntityes.FilterModelAndview;
using Inbrand.CoreEntityes.APIResponses;
using Inbrand.CoreEntities;
using Inbrand.CoreEntityes.Models;

namespace InbrandInterface.ServiceInterface
{
   public interface IArticleService
    {
        List<_Article> All(string articleid);
        Task<APIResponse> ValidateSubscriptionById(List<SubscriptionsModel> listsubscription);
        //List<_Article> GetActiveArticles(string articleid);
        object GetActiveArticles(string articleid);
        //object GetMyActiveArticles(string articleid);
        List<_Article> GetMyActiveArticles(string articleid);
    }
}
