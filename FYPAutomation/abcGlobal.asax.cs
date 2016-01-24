using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using FYPAutomation;
using FYPAutomation.App_Start;
using FYPDAL;

namespace FYPAutomation
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Application["sessionCount"] = 0;
            //FrequentAccesses.GetAllAssignedProjects();
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            Application["sessionCount"] = ((int) Application["sessionCount"]) + 1;
        }

        void Session_End(object sender, EventArgs e)
        {
            Application["sessionCount"] = ((int)Application["sessionCount"]) - 1;
        }
    }
}
