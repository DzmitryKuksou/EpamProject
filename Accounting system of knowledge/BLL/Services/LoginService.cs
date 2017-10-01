using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Repositories;
using DAL.Interface.DTO;
using BLL.Interface.Entities;
using BLL.Mappers;

namespace BLL.Interface.Services
{
    public class LoginService:ILoginService
    {
        private readonly IUnitOfWork uow;
        public LoginService(IUnitOfWork uow)
        {
            this.uow = uow; ;
        }
        public void Create(BLLLogin prog)
        {
            DALLogin dallog = LoginMapper.GetDALEntity(prog);
            if (!IsEmailEnabled(dallog.Mail)) throw new Exception("User with such email is exists!");
            if (!IsLoginEnabled(dallog.Login)) throw new Exception("User with such login is exists!");
            uow.Logins.Create(dallog);
            uow.Programmers.Create(new DALProgrammer() { Id = dallog.Id });
            uow.Commit();
        }
        public void UpDate(BLLLogin prog)
        {
            uow.Logins.UpDate(LoginMapper.GetDALEntity(prog));
            uow.Commit();
        }
        public void Delete(int id)
        {
            uow.Logins.Delete(uow.Logins.GetById(id));
            uow.Commit();
        }
        public BLLLogin Get(int id)
        {
            return LoginMapper.GetBLLEntity(uow.Logins.GetById(id));
        }
        public IEnumerable<BLLLogin> GetAll()
        {
            return LoginMapper.Map(uow.Logins.GetAll());
        }
        public IEnumerable<BLLCategory> GetUserSpheres(int userId)
        {
            return CategoryMapper.Map(uow.Spheres.GetUserSpheres(userId));
        }
        public BLLLogin Login(string mailOrLogin, string password)
        {
            DALLogin dalprog;
            if (IsEnabled(mailOrLogin, out dalprog))
            {
                if (IsPasswordEnabled(password))
                {
                    Expression<Func<DALLogin, bool>> expLogin = u => u.Login == mailOrLogin;
                    Expression<Func<DALLogin, bool>> expmail = u => u.Mail == mailOrLogin;
                    if (uow.Logins.GetByPredicate(expLogin) == null) return LoginMapper.GetBLLEntity(uow.Logins.GetByPredicate(expmail));
                    return LoginMapper.GetBLLEntity(uow.Logins.GetByPredicate(expLogin));
                }
            }
            throw new Exception("check your data!");
        }
        public void UpdateProgrammerSpheres(int userId, IEnumerable<BLLCategory> categories)
        {
            foreach (var category in categories)
            {
                foreach (var sphere in category.Sphere)
                {
                    uow.Spheres.UpdateSphereLevel(userId, sphere.Id, sphere.Level);
                }
            }
            uow.Commit();
        }
        public bool IsPasswordEnabled(string password)
        {
            Expression<Func<DALLogin, bool>> pass = l => l.Password == password;
            return (ReferenceEquals(uow.Logins.GetByPredicate(pass), null));
        }
        private bool IsEmailEnabled(string mail)
        {
            Expression<Func<DALLogin, bool>> expmail = l => l.Mail == mail;

            return (ReferenceEquals(uow.Logins.GetByPredicate(expmail), null));
        }
        private bool IsLoginEnabled(string login)
        {
            Expression<Func<DALLogin, bool>> expmail = l => l.Login == login;

            return (ReferenceEquals(uow.Logins.GetByPredicate(expmail), null));
        }
        private bool IsEnabled(string userData, out DALLogin dalUser)
        {
            Expression<Func<DALLogin, bool>> expLogin = u => u.Login == userData;
            Expression<Func<DALLogin, bool>> expEmail = u => u.Mail == userData;

            dalUser = (uow.Logins.GetByPredicate(expLogin));
            if (ReferenceEquals(dalUser, null)) dalUser = uow.Logins.GetByPredicate(expEmail);

            return !ReferenceEquals(dalUser, null);
        }
    }
}
