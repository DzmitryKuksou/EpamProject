using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interface.Entities;
using WebApp.Models;

namespace WebApp.Infrastructure.Mappers
{
    public class SphereMapper
    {
        public static BLLSphere GetBLLEntity(MvcSphere sphere)
        {
            return new BLLSphere()
            {
                Id = sphere.Id,
                Name = sphere.Name,
                Level = sphere.Level,
                CategoryName = sphere.CategoryName
            };
        }
        public static MvcSphere GetMVCEntity(BLLSphere sphere)
        {
            return new MvcSphere()
            {
                Id = sphere.Id,
                Name = sphere.Name,
                Level = sphere.Level,
                CategoryName = sphere.CategoryName
            };
        }
        public static SphereModel Map(BLLProgrammer_Sphere Programmer_Spheres)
        {
            var mvcSpheres = new List<MvcSphere>();
            var res = new SphereModel()
            {
                ProgId = Programmer_Spheres.IdProgrammer,
            };

            foreach (var item in Programmer_Spheres.Spheres)
            {
                res.Spheres.Add(GetMVCEntity(item));
            }
            return res;
        }
        public static IEnumerable<SphereModel> Map(IEnumerable<BLLProgrammer_Sphere> skills)
        {
            var List = new List<SphereModel>();
            foreach (var item in skills)
            {
                List.Add(Map(item));
            }

            return List;
        }
        public static IEnumerable<MvcSphere> Map(IEnumerable<BLLSphere> c)
        {
            var List = new List<MvcSphere>();

            foreach (var item in c)
            {
                List.Add(GetMVCEntity(item));
            }

            return List;
        }
    }
}