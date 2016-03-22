using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using HR_Portal.DataAccess.WorkUnit;
using HR_PortalInterfaces;
using HR_PortalWeb.Resolver;
using Microsoft.Practices.Unity;

namespace HR_PortalWeb.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container=new UnityContainer();
            container.RegisterType<IUnitOfWork, HR_PortalUnitOfWork>(new HierarchicalLifetimeManager());
            config.DependencyResolver=new UnityResolver(container);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}