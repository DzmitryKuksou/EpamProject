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
    public class CategoryRepository:ICategoryRepository
    {
        private readonly DbContext context;

        public CategoryRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Context is null!");
            }
            this.context = context;
        }

        public void Create(DALCategory e)
        {
            context.Set<Category>().Add(e.GetORMEntity());
        }

        public void Delete(DALCategory e)
        {
            context.Set<Category>().Attach(e.GetORMEntity());
            context.Set<Category>().Remove(e.GetORMEntity());
        }

        public void UpDate(DALCategory e)
        {

            context.Entry(e.GetORMEntity()).State = EntityState.Modified;
        }

        public IEnumerable<DALCategory> GetAll()
        {
            return context.Set<Category>().Select(category => category.GetDALEntity());
        }

        public DALCategory GetById(int key)
        {
            var ormCategory = context.Set<Category>().FirstOrDefault(role => role.Id == key);
            return ormCategory == null ? null : ormCategory.GetDALEntity();
        }

        public DALCategory GetByPredicate(Expression<Func<DALCategory, bool>> f)
        {
            return GetAllByPredicate(f).FirstOrDefault();
        }

        public IEnumerable<DALCategory> GetAllByPredicate(Expression<Func<DALCategory, bool>> f)
        {
            var visitor =
                new HelperExpressionVisitor<DALCategory, Category>(Expression.Parameter(typeof(Category), f.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<Category, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            return context.Set<Category>()
                .Where(exp2)
                .Select(r => r.GetDALEntity());
        }
    }
}
