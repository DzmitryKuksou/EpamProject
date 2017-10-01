using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using DAL.Interface.Repositories;
using BLL.Interface.Entities;
using BLL.Interface.Services;

namespace BLL.Mappers
{
    public static class LoginMapper
    {
        public static BLLLogin GetBLLEntity(DALLogin dalEntity)
        {
            if (dalEntity == null)
                throw new ArgumentNullException();
            return new BLLLogin()
            {
                Id = dalEntity.Id,
                Login = dalEntity.Login,
                Mail = dalEntity.Mail,
                Password = dalEntity.Password,
                IdProgrammer = dalEntity.IdProgrammer,
                IdRole = dalEntity.IdRole,
                Roles = dalEntity.Roles,
            };
        }

        public static DALLogin GetDALEntity(BLLLogin bllEntity)
        {
            if (bllEntity == null)
                throw new ArgumentNullException();
            return new DALLogin()
            {
                Id = bllEntity.Id,
                Login = bllEntity.Login,
                Mail = bllEntity.Mail,
                Password = bllEntity.Password,
                IdProgrammer = bllEntity.IdProgrammer,
                IdRole = bllEntity.IdRole,
                Roles = bllEntity.Roles,
        };
        }
        public static IEnumerable<BLLLogin> Map(IEnumerable<DALLogin> dalEntity)
        {
            if (dalEntity == null)
                throw new ArgumentNullException();
            var List = new List<BLLLogin>();
            foreach(var item in dalEntity)
            {
                List.Add(GetBLLEntity(item));
            }
            return List;
        }
    }
}
