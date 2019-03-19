using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Inbrand.Models
{
    public class ExceptionHandler: ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            string ExceptionMsg = string.Empty;
            if (actionExecutedContext.Exception.InnerException != null)
                ExceptionMsg = actionExecutedContext.Exception.InnerException.Message;
            else
                ExceptionMsg = actionExecutedContext.Exception.Message;
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest) { Content = new StringContent(ExceptionMsg) };
            actionExecutedContext.Response = response;
        }
    }
}