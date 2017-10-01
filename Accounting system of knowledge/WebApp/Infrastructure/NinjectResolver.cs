using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ninject;
using DependencyResolver;

namespace WebApp.Infrastructure
{
    public class NinjectResolver :IDependencyResolver
    {
        private IKernel kernel;
        public NinjectResolver()
        {
            kernel = new StandardKernel();
            kernel.Configure();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}