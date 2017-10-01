using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;

namespace DAL.Interface.Repositories
{
    public interface ILoginRepository
    {
        void Create(DALLogin entity);
        void Delete(DALLogin entity);
        void UpDate(DALLogin entity);
        IEnumerable<DALLogin> GetAll();
        DALLogin GetById(int key);
        DALLogin GetByPredicate(Expression<Func<DALLogin, bool>> predicate);
        IEnumerable<DALLogin> GetAllByPredicate(Expression<Func<DALLogin, bool>> predicate);
    }
}
