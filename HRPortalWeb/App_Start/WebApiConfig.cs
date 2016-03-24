using System.Web.Http;
using HRPortal.DataAccess.WorkUnit;
using HRPortalInterfaces;
using HRPortalWeb.Resolver;
using Microsoft.Practices.Unity;

namespace HRPortalWeb.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container=new UnityContainer();
            container.RegisterType<IUnitOfWork, HRPortalUnitOfWork>(new HierarchicalLifetimeManager());
            config.DependencyResolver=new UnityResolver(container);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}