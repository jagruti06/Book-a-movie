using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Project5WebApp
{
    public class Global : HttpApplication
    {
        public static string startTime;
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            startTime = DateTime.Now.ToString("hh:mm:ss tt");

            Application["UsersOnline"] = 0;
            //Application["SessionTimedOut"] = "";
        }

        void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();
            Session["verfstr"] = "";
            Session["count"] = 0;
            Application["UsersOnline"] = (int)Application["UsersOnline"] + 1;
            Application.UnLock();
            Session.Timeout = 1;
        }
        void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["UsersOnline"] = (int)Application["UsersOnline"] - 1;
            Application.UnLock();
            //Application["SessionTimedOut"] = "true";


        }
    }
}