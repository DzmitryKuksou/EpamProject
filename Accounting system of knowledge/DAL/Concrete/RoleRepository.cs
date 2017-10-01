//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;
//using DAL.Interface.Repositories;
//using System.Data.Entity;
//using DAL.Interface.DTO;
//using ORM;
//using DAL.Mappers;

//namespace DAL.Concrete
//{
//    public class RoleRepository:IRoleRepository
//    {
//        private readonly DbContext context;

//        public RoleRepository(DbContext context)
//        {
//            if (context == null)
//            {
//                throw new ArgumentNullException("Context is null!");
//            }
//            this.context = context;
//        }

//        public void Create(DALRole e)
//        {
//            context.Set<Role>().Add(e.GetORMEntity());
//        }

//        public void Delete(DALRole e)
//        {
//            context.Set<Role>().Attach(e.GetORMEntity());
//            context.Set<Role>().Remove(e.GetORMEntity());
//        }

//        public void UpDate(DALRole e)
//        {

//            context.Entry(e.GetORMEntity()).State = EntityState.Modified;
//        }

//        public IEnumerable<DALRole> GetAll()
//        {
//            return context.Set<Role>().Select(sphere => sphere.GetDALEntity());
//        }

//        public DALRole GetById(int key)
//        {
//            var ormSphere = context.Set<Role>().FirstOrDefault(role => role.Id == key);
//            return ormSphere == null ? null : ormSphere.GetDALEntity();
//        }

//        public DALRole GetByPredicate(Expression<Func<DALRole, bool>> f)
//        {
//            return GetAllByPredicate(f).FirstOrDefault();
//        }

//        public IEnumerable<DALRole> GetAllByPredicate(Expression<Func<DALRole, bool>> f)
//        {
//            var visitor =
//                new HelperExpressionVisitor<DALRole, Role>(Expression.Parameter(typeof(Role), f.Parameters[0].Name));
//            var exp2 = Expression.Lambda<Func<Role, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
//            return context.Set<Role>()
//                .Where(exp2)
//                .Select(r => r.GetDALEntity());
//        }
//    }
//}
