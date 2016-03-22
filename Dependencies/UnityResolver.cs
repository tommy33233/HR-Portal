using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;
using IDependencyResolver = System.Web.Mvc.IDependencyResolver;

namespace Dependencies
{
    class UnityResolver//:IDependencyResolver
    {
        protected IUnityContainer container;

        public UnityResolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }
/*
        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new UnityResolver(child);
        }
*/
        public void Dispose()
        {
            container.Dispose();
        }
    }
}
