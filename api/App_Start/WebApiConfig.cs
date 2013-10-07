using System.Web.Http;

namespace api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;



            config.Routes.MapHttpRoute(
                name: "childApi",
                routeTemplate: "api/Jobs/{jobId}/People/{param}",
                defaults: new { controller = "People",  Action = "getByJob", param = RouteParameter.Optional }
            );


          


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
