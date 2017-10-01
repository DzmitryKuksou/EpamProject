using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;
using DAL.Interface.DTO;

namespace DAL.Mappers
{
    public static class RoleMappers
    {
        public static Role GetORMEntity(this DALRole DalEntity)
        {
            if (DalEntity == null)
                throw new ArgumentNullException($"{DalEntity} is null!");
            var newRole = new Role()
            {
                Id = DalEntity.Id,
                Name = DalEntity.Name
            };
            foreach(var programmers in DalEntity.Login_Mail)
            {
                newRole.Login_Mail.Add(programmers.GetORMEntity());
            }
            return newRole;
        }

        public static DALRole GetDALEntity(this Role ORMEntity)
        {
            if (ORMEntity == null)
                throw new ArgumentNullException($"{ORMEntity} is null!");
            var newDALRole = new DALRole()
            {
                Id = ORMEntity.Id,
                Name = ORMEntity.Name
            };
            foreach (var programmers in ORMEntity.Login_Mail)
            {
                newDALRole.Login_Mail.Add(programmers.GetDALEntity());
            }
            return newDALRole;
        }
    }
}
