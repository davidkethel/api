using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http.Headers;
using System.Net;

namespace api.HttpModules
{
    public class BasicAuthHttpModule : IHttpModule
    {



        public void Init(HttpApplication context)
        {
            // Register Event Handelers
            context.AuthenticateRequest += OnApplicationAuthenticateRequest;
            context.EndRequest += OnApplicationEndRequest;
        }



        private static bool AuthenticateUser(string credentials)
        {
            return false;
        }

        private static void OnApplicationAuthenticateRequest(Object sender, EventArgs e)
        {
            var request = HttpContext.Current.Request;
            var authHeader = request.Headers["Authorization"];

            if (authHeader != null)
            {
                var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

                if (authHeaderVal.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) && authHeaderVal.Parameter != null)
                {
                    AuthenticateUser(authHeaderVal.Parameter);

                }
            }
            else
            {
                HttpContext.Current.Response.StatusCode =  (int)HttpStatusCode.Unauthorized;
            }
        }


        private static void OnApplicationEndRequest(object sender, EventArgs e)
        {
            var response = HttpContext.Current.Response;
            if (response.StatusCode == 401)
            {
                response.Headers.Add("WWW-Authenticate",string.Format("Basic Realm = Dave"));
            }

        }

        public void Dispose() { }

    }
}