
using System.Web.Mvc;
using HR_Portal.DataAccess.WorkUnit;
using HR_PortalInterfaces;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;

namespace HR_PortalWeb.Resolver
{
    public static class Boostrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();
            //GlobalConfiguration.Configuration.DependencyResolver=new Unity.WebApi.UnityDependencyResolver(container);
           
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
           RegisterTypes(container);
            return container;
        }


        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IUnitOfWork, HR_PortalUnitOfWork>();
        }
    }

   
}