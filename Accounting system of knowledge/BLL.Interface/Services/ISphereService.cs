using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Interface.Services
{
    public interface ISphereService
    {
        void Create(BLLSphere entity);
        void Delete(int id);
        void UpDate(BLLSphere sphere);
        BLLSphere Get(int id);
        IEnumerable<BLLSphere> GetAll();
        IEnumerable<BLLProgrammer_Sphere> RateProgrammers(IEnumerable<string> sortings);
    }
}
