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
    public class CategoryMapper
    {
        public static BLLCategory GetBLLEntity(DALCategory category)
        {
            BLLCategory result = new BLLCategory()
            {
                Id = category.Id,
                Name = category.Name
            };
            foreach (var sphere in category.Sphere)
            {
                result.Sphere.Add(SphereMapper.GetBLLEntity(sphere));
            }
            return result;
        }

        public static DALCategory GetDALEntity(BLLCategory category)
        {
            DALCategory result = new DALCategory()
            {
                Id = category.Id,
                Name = category.Name
            };
            foreach (var sphere in category.Sphere)
            {
                result.Sphere.Add(SphereMapper.GetDALEntity(sphere));
            }
            return result;
        }

        public static IEnumerable<BLLCategory> Map(IEnumerable<DALCategory> categories)
        {
            List<BLLCategory> result = new List<BLLCategory>();
            foreach (var item in categories)
            {
                result.Add(GetBLLEntity(item));
            }

            return result;
        }
    }
}
