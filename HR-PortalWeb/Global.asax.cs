using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NLog;
using System.Web.Http;
using HR_PortalWeb.App_Start;
using HR_PortalWeb.Resolver;
using System.Web.Optimization;


namespace HR_PortalWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {

        //Logger logger = LogManager.GetCurrentClassLogger();
        protected void Application_Start()
        {
            // logger.Info("start");
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AreaRegistration.RegisterAllAreas();
          
            GlobalConfiguration.Configure(WebApiConfig.Register);
          
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Boostrapper.Initialise();
        }
    }
}
