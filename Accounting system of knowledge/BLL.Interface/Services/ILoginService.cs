using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Repositories;
using DAL.Interface.DTO;
using BLL.Interface.Entities;
namespace BLL.Interface.Services
{
    public interface ILoginService
    {
        void Create(BLLLogin entity);
        void Delete(int entity);
        void UpDate(BLLLogin prog);
        BLLLogin Get(int id);
        IEnumerable<BLLLogin> GetAll();
        BLLLogin Login(string emailOrLogin, string password);
        void UpdateProgrammerSpheres(int userId, IEnumerable<BLLCategory> categories);
        IEnumerable<BLLCategory> GetUserSpheres(int userId);
    }
}
