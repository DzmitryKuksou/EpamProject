using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Repositories;
using System.Data.Entity;

namespace DAL.Interface.Repositories
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; set; }
        IProgrammerRepository Programmers { get; set; }
        ISphereRepository Spheres { get; set; }
        ILoginRepository Logins { get; set; }
        void Commit();
    }
}
