using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Web.Common;
using Ninject;
using DAL.Interface.Repositories;
using DAL.Concrete;
using BLL.Interface.Services;
using ORM;
using System.Data.Entity;

namespace DependencyResolver
{
    public static class DependencyResolver
    {
        public static void Configure(this IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<DbContext>().To<Accountimg_system_of_knowledgeEntities>().InRequestScope();


            kernel.Bind<IProgrammerService>().To<ProgrammerService>();
            kernel.Bind<ISphereService>().To<SphereService>();
            kernel.Bind<ILoginService>().To<LoginService>();
            kernel.Bind<ICategoryService>().To<CategoryService>();

            kernel.Bind<IProgrammerRepository>().To<ProgrammerRepository>();
            kernel.Bind<ISphereRepository>().To<SphereRepository>();
            kernel.Bind<ILoginRepository>().To<LoginRepository>();
            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();
        }
    }
}
