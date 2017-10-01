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
    public class LoginRepository : ILoginRepository
    {
        private readonly DbContext context;

        public LoginRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Context is null!");
            }
            this.context = context;
        }

        public void Create(DALLogin e)
        {
            Login_Mail a = LoginMapper.GetORMEntity(e);
            context.Set<Login_Mail>().Add(a);
        }

        public void Delete(DALLogin e)
        {
            context.Set<Login_Mail>().Remove(context.Set<Login_Mail>().FirstOrDefault(u => u.Id == e.Id));
        }

        public void UpDate(DALLogin e)
        {

            context.Entry(e.GetORMEntity()).State = EntityState.Modified;
        }

        public IEnumerable<DALLogin> GetAll()
        {
            return LoginMapper.Map(context.Set<Login_Mail>().Select(pr => pr));
        }

        public DALLogin GetById(int key)
        {
            var ormLogin = context.Set<Login_Mail>().FirstOrDefault(login => login.Id == key);
            return ormLogin == null ? null : ormLogin.GetDALEntity();
        }

        public DALLogin GetByPredicate(Expression<Func<DALLogin, bool>> f)
        {
            return GetAllByPredicate(f).FirstOrDefault();
        }

        public IEnumerable<DALLogin> GetAllByPredicate(Expression<Func<DALLogin, bool>> f)
        {
            var visitor = new HelperExpressionVisitor<DALLogin, Login_Mail>(Expression.Parameter(typeof(Login_Mail), f.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<Login_Mail, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            var x = context.Set<Login_Mail>().Where(exp2).ToList();
            return x.Select(pr => pr.GetDALEntity());
        }
    }
}
