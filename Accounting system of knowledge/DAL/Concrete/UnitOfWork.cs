using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interface.Repositories;
using ORM;

namespace DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; private set; }
        public ICategoryRepository Categories { get; set; }
        public IProgrammerRepository Programmers { get; set; }
        public ISphereRepository Spheres { get; set; }
        public ILoginRepository Logins { get; set; }
        public UnitOfWork(DbContext context)
        {
            Context = context;
            Categories = new CategoryRepository((Accountimg_system_of_knowledgeEntities)context);
            Programmers = new ProgrammerRepository((Accountimg_system_of_knowledgeEntities)context);
            Spheres = new SphereRepository((Accountimg_system_of_knowledgeEntities)context);
            Logins = new LoginRepository((Accountimg_system_of_knowledgeEntities)context);
        }

        public void Commit()
        {
            if (Context != null)
                Context.SaveChanges();
        }

        public void Dispose()
        {
            if (Context != null)
                Context.Dispose();
        }
    }
}
