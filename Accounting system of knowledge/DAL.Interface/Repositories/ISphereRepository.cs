using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;

namespace DAL.Interface.Repositories
{
    public interface ISphereRepository
    {
        void Create(DALSphere entity);
        void Delete(DALSphere entity);
        void UpDate(DALSphere entity);
        IEnumerable<DALSphere> GetAll();
        DALSphere GetById(int key);
        DALSphere GetByPredicate(Expression<Func<DALSphere, bool>> predicate);
        IEnumerable<DALSphere> GetAllByPredicate(Expression<Func<DALSphere, bool>> predicate);
        IEnumerable<DALProgrammer> GetUsersWithSphere(DALSphere sphere);
        List<DALCategory> GetUserSpheres(int userId);
        void UpdateSphereLevel(int prId, int sphereId, int level);
        int GetLevelOfSphere(int progId, int sphereId);
    }
}
