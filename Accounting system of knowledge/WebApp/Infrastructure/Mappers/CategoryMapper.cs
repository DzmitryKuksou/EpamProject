using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;
using BLL.Interface.Entities;

namespace WebApp.Infrastructure.Mappers
{
    public class CategoryMapper
    {
        public static BLLCategory GetBLLEntity(MvcCategory category)
        {
            BLLCategory result = new BLLCategory()
            {
                Id = category.Id,
                Name = category.Name,
            };
            foreach (var sphere in category.Sphere)
            {
                result.Sphere.Add(SphereMapper.GetBLLEntity(sphere));
            }
            return result;
        }
        public static MvcCategory GetMVCEntity(BLLCategory category)
        {
            MvcCategory res = new MvcCategory()
            {
                Id = category.Id,
                Name = category.Name
            };
            foreach (var sphere in category.Sphere)
            {
                res.Sphere.Add(SphereMapper.GetMVCEntity(sphere));
            }
            return res;
        }
        public static IEnumerable<BLLCategory> Map(IEnumerable<MvcCategory> c)
        {
            var List = new List<BLLCategory>();
            foreach (var item in c)
            {
                List.Add(GetBLLEntity(item));
            }
            return List;
        }
        public static IEnumerable<MvcCategory> Map(IEnumerable<BLLCategory> c)
        {
            var List = new List<MvcCategory>();
            foreach (var item in c)
            {
                List.Add(GetMVCEntity(item));
            }
            return List;
        }
    }
}