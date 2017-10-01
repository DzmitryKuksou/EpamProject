using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using DAL.Interface.Repositories;
using BLL.Interface.Entities;

namespace BLL.Mappers
{
    public static class SphereMapper
    {
        public static BLLSphere GetBLLEntity(DALSphere dalEntity)
        {
            if (dalEntity == null)
                throw new ArgumentNullException();
            return new BLLSphere()
            {
                Id = dalEntity.Id,
                Name = dalEntity.Name,
                Level = dalEntity.Level,
                CategoryName = dalEntity.CategoryName,
            };
        }
        public static DALSphere GetDALEntity(BLLSphere bllEntity)
        {
            return new DALSphere()
            {
                Id = bllEntity.Id,
                Name = bllEntity.Name,
                Level = bllEntity.Level,
                CategoryName = bllEntity.CategoryName
            };
        }
        public static BLLProgrammer_Sphere GetBLLEntity(DALProgrammer_Sphere programmer_sphere)
        {
            var res = new BLLProgrammer_Sphere()
            {
                Id = programmer_sphere.Id,
                IdSphere = programmer_sphere.IdSphere,
                IdProgrammer = programmer_sphere.IdProgrammer,
            };
            foreach (var item in programmer_sphere.Spheres)
            {
                res.Spheres.Add(GetBLLEntity(item));
            }

            return res;
        }
        public static IEnumerable<BLLSphere> Map(IEnumerable<DALSphere> Sphere)
        {
            var List = new List<BLLSphere>();
            foreach (var item in Sphere)
            {
                List.Add(GetBLLEntity(item));
            }

            return List;
        }
    }
}
