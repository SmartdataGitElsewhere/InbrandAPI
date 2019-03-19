using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inbrand.CoreEntityes.FilterModelAndview;
using Inbrand.CoreEntityes.APIResponses;
using Inbrand.CoreEntities;
using Inbrand.CoreEntityes.Models;
using FortnoxAPILibrary;

namespace Inbrand.FrotNoxAPI.Interface
{
   public interface IArticleRepository
    {
        List<_Article> All(string articleid);
        Task<APIResponse> ValidateSubscriptionById(List<SubscriptionsModel> listsubscription);
        List<_Article> ConvertToArticleView(List<ArticleSubset> articles, string articleid);
        // List<_Article> ConvertToActiveArticleView(List<Articless> articles, string articleid);
        object ConvertToActiveArticleView(List<Articless> articles, string articleid);

        //object MyConvertToActiveArticleView(List<Articless> articles, string articleid);
        List<_Article> MyConvertToActiveArticleView(List<Articless> articles, string articleid);
    }
}
