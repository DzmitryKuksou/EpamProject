using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;
using DAL.Interface.DTO;

namespace DAL.Mappers
{
    public static class ProgrammerMapper
    {
        public static Programmer GetORMEntity(this DALProgrammer DalEntity)
        {
            if (DalEntity == null)
                throw new ArgumentNullException($"{DalEntity} is null!");

            return new Programmer
            {
                Id = DalEntity.Id,
                Name = DalEntity.Name,
                Surname = DalEntity.Surname,
                Salary = DalEntity.Salary,
                Age = DalEntity.Age
            };

        }
        public static DALProgrammer GetDALEntity(this Programmer ORMEntity)
        {
            if(ORMEntity == null)
                throw new ArgumentNullException($"{ORMEntity} is null!");

            return new DALProgrammer
            {
                Id = ORMEntity.Id,
                Name = ORMEntity.Name,
                Surname = ORMEntity.Surname,
                Salary = (decimal)ORMEntity.Salary,
                Age = (int)ORMEntity.Age
            };
        }
    }
}
