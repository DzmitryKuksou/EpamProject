using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using DAL.Interface.Repositories;
using BLL.Interface.Entities;

namespace BLL.Mappers
{
    public static class ProgrammerMapper
    {
        public static BLLProgrammer GetBLLEntity(this DALProgrammer dalEntity)
        {
            if (dalEntity == null)
                return null;
            return new BLLProgrammer()
            {
                Id = dalEntity.Id,
                Name = dalEntity.Name,
                Surname = dalEntity.Surname,
                Age = dalEntity.Age,
                Salary = dalEntity.Salary,
            };
        }

        public static DALProgrammer GetDALEntity(this BLLProgrammer bllEntity)
        {
            if (bllEntity == null)
                return null;
            return new DALProgrammer()
            {
                Id = bllEntity.Id,
                Name = bllEntity.Name,
                Surname = bllEntity.Surname,
                Age = bllEntity.Age,
                Salary = bllEntity.Salary,
            };
        }
    }
}
