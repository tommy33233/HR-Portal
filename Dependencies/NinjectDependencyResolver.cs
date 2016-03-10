using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using System.Web.Mvc;
using HR_PortalInterfaces;
using Logger;
using HR_Portal.DataAccess.WorkUnit;

namespace Dependencies
{
   public class NinjectDependencyResolver:IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IUnitOfWork>().To<HR_PortalUnitOfWork>();
            kernel.Bind<ILogger>().To<DebugLogger>();
            kernel.Bind<ILogger>().To<FileSystemLogger>();
            kernel.Bind<ILogger>().To<DebugLogger>();
        }
    }
}
