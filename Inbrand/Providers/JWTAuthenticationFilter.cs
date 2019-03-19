using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Inbrand.Providers
{
    public class JWTAuthenticationFilter : AuthorizationFilterAttribute
    {
        //public override void OnAuthorization(HttpActionContext filterContext)
        //{

        //    //if (!IsUserAuthorized(filterContext))
        //    //{
        //    //    ShowAuthenticationError(filterContext);
        //    //    return;
        //    //}
        //    //base.OnAuthorization(filterContext);
        //}
    }
}