using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace FYPAutomation.App_Start
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.EnableFriendlyUrls();
        }
    }
}
