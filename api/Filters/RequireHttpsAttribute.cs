using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace api.Filters
{
    public class RequireHttpsAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {

            if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {

                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                {
                    ReasonPhrase = "Https Required"
                };
            }
            else
            {
                base.OnAuthorization(actionContext);
            }

        }
    }
}