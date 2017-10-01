using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Repositories;
using System.Data.Entity;
using DAL.Interface.DTO;
using ORM;
using DAL.Mappers;

namespace DAL.Concrete
{
    public class ProgrammerRepository:IProgrammerRepository
    {
        private readonly DbContext context;
        public ProgrammerRepository(DbContext context)
        {
            this.context = context;
        }
        public void Create(DALProgrammer e)
        {
            context.Set<Programmer>().Add(e.GetORMEntity());
        }

        public void Delete(DALProgrammer e)
        {
            context.Set<Programmer>().Attach(e.GetORMEntity());
            context.Set<Programmer>().Remove(e.GetORMEntity());
        }

        public void UpDate(DALProgrammer e)
        {

            context.Entry(e.GetORMEntity()).State = EntityState.Modified;
        }

        public IEnumerable<DALProgrammer> GetAll()
        {
            return context.Set<Programmer>().Select(programmer => programmer.GetDALEntity());
        }

        public DALProgrammer GetById(int key)
        {
            var ormProgrammer = context.Set<Programmer>().FirstOrDefault(programmer => programmer.Id == key);
            return ormProgrammer == null ? null : ormProgrammer.GetDALEntity();
        }

        public DALProgrammer GetByPredicate(Expression<Func<DALProgrammer, bool>> f)
        {
            return GetAllByPredicate(f).FirstOrDefault();
        }

        public IEnumerable<DALProgrammer> GetAllByPredicate(Expression<Func<DALProgrammer, bool>> f)
        {
            var visitor =
                new HelperExpressionVisitor<DALProgrammer, Programmer>(Expression.Parameter(typeof(Programmer), f.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<Programmer, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            return context.Set<Programmer>()
                .Where(exp2)
                .Select(r => r.GetDALEntity());
        }
    }
}
