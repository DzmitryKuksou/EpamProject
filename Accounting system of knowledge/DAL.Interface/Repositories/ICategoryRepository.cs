using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;

namespace DAL.Interface.Repositories
{
    public interface ICategoryRepository
    {
        void Create(DALCategory entity);
        void Delete(DALCategory entity);
        void UpDate(DALCategory entity);
        IEnumerable<DALCategory> GetAll();
        DALCategory GetById(int key);
        DALCategory GetByPredicate(Expression<Func<DALCategory, bool>> predicate);
        IEnumerable<DALCategory> GetAllByPredicate(Expression<Func<DALCategory, bool>> predicate);
    }
}
