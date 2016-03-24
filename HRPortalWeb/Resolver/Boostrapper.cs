using System.Web.Mvc;
using HRPortal.DataAccess.WorkUnit;
using HRPortalInterfaces;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;

namespace HRPortalWeb.Resolver
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
            container.RegisterType<IUnitOfWork, HRPortalUnitOfWork>();
        }
    }

   
}