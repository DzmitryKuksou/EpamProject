using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
namespace BLL.Interface.Services
{
    public interface ICategoryService
    {
        IEnumerable<BLLCategory> Find(string stringKey);
        void Update(BLLCategory category);
        void Create(BLLCategory entity);
        void Delete(int id);
        IEnumerable<BLLCategory> GetAll();
        BLLCategory Get(int id);
    }
}
