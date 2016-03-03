using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NLog;

namespace HR_PortalWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {

        Logger logger = LogManager.GetCurrentClassLogger();
        protected void Application_Start()
        {
            logger.Info("start");
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
