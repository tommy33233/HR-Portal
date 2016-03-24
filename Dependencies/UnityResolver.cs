using System;
using Microsoft.Practices.Unity;

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
