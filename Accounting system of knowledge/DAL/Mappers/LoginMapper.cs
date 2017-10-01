using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class LoginMapper
    {
        public static Login_Mail GetORMEntity(this DALLogin DalEntity)
        {
            if (DalEntity == null)
                throw new ArgumentNullException($"{DalEntity} is null!");

            return new Login_Mail
            {
                Id = DalEntity.Id,
                Login = DalEntity.Login,
                Mail = DalEntity.Mail,
                //IdProgrammer = DalEntity.IdProgrammer,
                //IdRole = DalEntity.IdRole,
                Password = DalEntity.Password,
            };
        }
        public static DALLogin GetDALEntity(this Login_Mail ORMEntity)
        {
            if (ORMEntity == null)
                throw new ArgumentNullException($"{ORMEntity} is null!");

            return new DALLogin()
            {
                Id = ORMEntity.Id,
                Login = ORMEntity.Login,
                Mail = ORMEntity.Mail,
                //IdProgrammer = (int)ORMEntity.IdProgrammer,
                //IdRole = (int)ORMEntity.IdRole,
                Password = ORMEntity.Password,
            };
        }
        public static IEnumerable<DALLogin> Map(IQueryable<Login_Mail> users)
        {
            var dal = new List<DALLogin>();
            foreach (var item in users)
            {
                dal.Add(GetDALEntity(item));
            }
            return dal;
        }
    }
}
