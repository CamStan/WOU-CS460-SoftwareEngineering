using System.Web.Mvc;
using System.Web.Routing;

namespace HW7
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*
             * Routing for the Stocks action method with 'symbol' parameter
             */
            routes.MapRoute(
                name: "Stock",
                url: "Home/Stocks/{symbol}",
                defaults: new {controller = "Home", action = "Stocks", symbol = UrlParameter.Optional }
            );

            /*
             * Routing for the Definition action method with 'key' parameter
             */
            routes.MapRoute(
                name: "Defintion",
                url: "Home/Definition/{key}",
                defaults: new {controller = "Home", action = "Definition", symbol = UrlParameter.Optional}    
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
