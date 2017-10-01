using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class SphereMapper
    {
        public static Sphere GetORMEntity(this DALSphere DalEntity)
        {
            if (DalEntity == null)
                throw new ArgumentNullException($"{DalEntity} is null!");
            return new Sphere()
            {
                Id = DalEntity.Id,
                Name = DalEntity.Name,
                //IdCategory = DalEntity.IdCategory,
                
    };
        }

        public static DALSphere GetDALEntity(this Sphere ORMEntity)
        {
            if (ORMEntity == null)
                throw new ArgumentNullException($"{ORMEntity} is null!");
            return new DALSphere()
            {
                Id = ORMEntity.Id,
                Name = ORMEntity.Name,
                //IdCategory = (int)ORMEntity.IdCategory,
                CategoryName = ORMEntity.Category.Name,
            };
        }

    }
}
