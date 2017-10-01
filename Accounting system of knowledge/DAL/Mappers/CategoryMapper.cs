using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class CategoryMapper
    {
        public static Category GetORMEntity(this DALCategory DalEntity)
        {
            if (DalEntity == null)
                throw new ArgumentNullException($"{DalEntity} is null!");

         var newCategory = new Category
            {
                Id = DalEntity.Id,
                Name = DalEntity.Name,
            };
            foreach (var sphere in DalEntity.Sphere)
            {
                newCategory.Sphere.Add(sphere.GetORMEntity());
            }
            return newCategory;
        }
        public static DALCategory GetDALEntity(this Category ORMEntity)
        {
            if (ORMEntity == null)
                throw new ArgumentNullException($"{ORMEntity} is null!");

            var newDALCategory = new DALCategory
            {
                Id = ORMEntity.Id,
                Name = ORMEntity.Name,
            };
            foreach (var sphere in ORMEntity.Sphere)
            {
                newDALCategory.Sphere.Add(sphere.GetDALEntity());
            }
            return newDALCategory;
        }
        public static IEnumerable<DALCategory> Map(IEnumerable<Category> category)
        {
            var List = new List<DALCategory>();
            foreach (var item in category)
            {
                List.Add(GetDALEntity(item));
            }
            return List;
        }
    }
}
