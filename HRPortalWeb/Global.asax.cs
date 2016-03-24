using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using HRPortalWeb.App_Start;
using HRPortalWeb.Resolver;
using System.Web.Optimization;


namespace HRPortalWeb
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
