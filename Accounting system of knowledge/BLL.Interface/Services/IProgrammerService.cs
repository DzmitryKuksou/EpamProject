using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IProgrammerService
    {
        BLLProgrammer Get(int id);
        void UpDate(BLLProgrammer login);
    }
}
