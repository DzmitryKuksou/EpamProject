using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Services;
using BLL.Interface.Entities;
using DAL.Interface.Repositories;
using DAL.Interface.DTO;
using BLL.Mappers;

namespace BLL.Interface.Services
{
    public class SphereService:ISphereService
    {
        private readonly IUnitOfWork uow;
        public SphereService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public void Create(BLLSphere sphere)
        {
            uow.Spheres.Create(SphereMapper.GetDALEntity(sphere));
            uow.Commit();
        }
        public void UpDate(BLLSphere sphere)
        {
            uow.Spheres.UpDate(SphereMapper.GetDALEntity(sphere));
            uow.Commit();
        }
        public void Delete(int id)
        {
            uow.Spheres.Delete(uow.Spheres.GetById(id));
            uow.Commit();
        }
        public BLLSphere Get(int id)
        {
            return SphereMapper.GetBLLEntity(uow.Spheres.GetById(id));
        }
        public IEnumerable<BLLSphere> GetAll()
        {
            return uow.Spheres.GetAll().Select(s => SphereMapper.GetBLLEntity(s));
        }
        public IEnumerable<BLLProgrammer_Sphere> RateProgrammers(IEnumerable<string> sortings)
        {
            var res = new List<BLLProgrammer_Sphere>();
            var Spheres = GetSphere(sortings);

            var users = uow.Programmers.GetAll();
            foreach (var item in Spheres)
            {
                users = users.Intersect(uow.Spheres.GetUsersWithSphere(item), new UserComparer());
            }

            foreach (var user in users)
            {
                var userSkills = new BLLProgrammer_Sphere();
                var userProfile = uow.Programmers.GetById(user.Id);
                userSkills.IdProgrammer= user.Id;
                foreach (var sphere in Spheres)
                {
                    var bllsphere = SphereMapper.GetBLLEntity(sphere);
                    bllsphere.Level = uow.Spheres.GetLevelOfSphere(user.Id, sphere.Id);
                    userSkills.Spheres.Add(bllsphere);
                }
                res.Add(userSkills);
            }

            return res;
        }

        private class UserComparer : IEqualityComparer<DALProgrammer>
        {
            public bool Equals(DALProgrammer x, DALProgrammer y)
            {
                return (x.Id == y.Id);
            }

            public int GetHashCode(DALProgrammer obj)
            {
                return (obj.Id * 100);
            }
        }
        internal IEnumerable<DALSphere> GetSphere(IEnumerable<string> names)
        {
            if (ReferenceEquals(names, null)) return new List<DALSphere>() { uow.Spheres.GetAll().First() };

            var result = new List<DALSphere>();
            foreach (var item in names)
            {
                result.Add(uow.Spheres.GetAll().FirstOrDefault(s => s.Name == item));
            }
            result.RemoveAll(item => item == null);
            return result;
        }
    }
}
