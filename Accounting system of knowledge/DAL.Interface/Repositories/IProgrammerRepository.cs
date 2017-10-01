using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;

namespace DAL.Interface.Repositories
{
    public interface IProgrammerRepository
    {
        void Create(DALProgrammer entity);
        void Delete(DALProgrammer entity);
        void UpDate(DALProgrammer entity);
        IEnumerable<DALProgrammer> GetAll();
        DALProgrammer GetById(int key);
        DALProgrammer GetByPredicate(Expression<Func<DALProgrammer, bool>> predicate);
        IEnumerable<DALProgrammer> GetAllByPredicate(Expression<Func<DALProgrammer, bool>> predicate);
    }
}
