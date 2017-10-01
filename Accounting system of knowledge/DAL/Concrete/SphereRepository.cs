using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Repositories;
using System.Data.Entity;
using DAL.Interface.DTO;
using ORM;
using DAL.Mappers;

namespace DAL.Concrete
{
    public class SphereRepository:ISphereRepository
    {
        private readonly DbContext context;

        public SphereRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Context is null!");
            }
            this.context = context;
        }

        public void Create(DALSphere e)
        {
            context.Set<Sphere>().Add(e.GetORMEntity());
        }

        public void Delete(DALSphere e)
        {
            context.Set<Sphere>().Attach(e.GetORMEntity());
            context.Set<Sphere>().Remove(e.GetORMEntity());
        }

        public void UpDate(DALSphere e)
        {

            context.Entry(e.GetORMEntity()).State = EntityState.Modified;
        }

        public IEnumerable<DALSphere> GetAll()
        {
            return context.Set<Sphere>().Select(sphere => sphere.GetDALEntity());
        }

        public DALSphere GetById(int key)
        {
            var ormSphere = context.Set<Sphere>().FirstOrDefault(sphere => sphere.Id == key);
            return ormSphere == null ? null : ormSphere.GetDALEntity();
        }

        public DALSphere GetByPredicate(Expression<Func<DALSphere, bool>> f)
        {
            return GetAllByPredicate(f).FirstOrDefault();
        }

        public IEnumerable<DALSphere> GetAllByPredicate(Expression<Func<DALSphere, bool>> f)
        {
            var visitor =
                new HelperExpressionVisitor<DALSphere, Sphere>(Expression.Parameter(typeof(Sphere), f.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<Sphere, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            return context.Set<Sphere>()
                .Where(exp2)
                .Select(r => r.GetDALEntity());
        }
        public IEnumerable<DALProgrammer> GetUsersWithSphere(DALSphere sphere)
        {
            return context.Set<Programmer_Sphere>().Where(pr => pr.IdSphere == sphere.Id).Select(pr => pr.Programmer.GetDALEntity());
        }
        public List<DALCategory> GetUserSpheres(int userId)
        {
            var sphereInCategories = CategoryMapper.Map(context.Set<Category>().Select(c => c).Include(c => c.Sphere));
            foreach (var item in sphereInCategories)
            {
                foreach (var sphere in item.Sphere)
                {
                    var userSphere = context.Set<Programmer_Sphere>().FirstOrDefault(us => us.IdProgrammer == userId && us.IdSphere == sphere.Id);
                    sphere.Level = ReferenceEquals(context.Set<Programmer_Sphere>(), null) ? 0 : (int)userSphere.Level;
                }
            }
            return sphereInCategories.ToList();
        }
        public void UpdateUserSpheres(int userId, IDictionary<int, int> SphereLevel)
        {
            foreach (var item in SphereLevel)
            {
                UpdateSphereLevel(userId, item.Key, item.Value);
            };
        }
        public void UpdateSphereLevel(int prId, int sphereId, int level)
        {
            var programmer_sphere = context.Set<Programmer_Sphere>().FirstOrDefault(pr => pr.IdProgrammer == prId && pr.IdSphere == sphereId);
            if (!ReferenceEquals(programmer_sphere, null))
            {
                programmer_sphere.Level = level;
                context.Entry(programmer_sphere).State = EntityState.Modified;
            }
            else
            {
                programmer_sphere = new Programmer_Sphere()
                {
                    Programmer = context.Set<Programmer>().FirstOrDefault(u => u.Id == prId),
                    Sphere= context.Set<Sphere>().FirstOrDefault(s => s.Id == sphereId),
                };
                context.Set<Programmer_Sphere>().Add(programmer_sphere);
            }
        }
        public int GetLevelOfSphere(int progId, int sphereId)
        {
            return (int)context.Set<Programmer_Sphere>().FirstOrDefault(pr => pr.Sphere.Id == sphereId && pr.IdProgrammer == progId).Level;
        }
    }
}
