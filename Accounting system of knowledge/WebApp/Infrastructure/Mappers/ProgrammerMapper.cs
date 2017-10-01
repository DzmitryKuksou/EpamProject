using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interface.Entities;
using WebApp.Models;

namespace WebApp.Infrastructure.Mappers
{
    public class ProgrammerMapper
    {
        public static BLLProgrammer GetBLLEntity(MvcProgrammer prog)
        {
            return new BLLProgrammer()
            {
                Id = prog.Id,
                Name = prog.Name,
                Surname = prog.Surname,
                Age = prog.Age,
                Salary = prog.Salary,
            };
        }
        public static MvcProgrammer Map(BLLProgrammer prog)
        {
            return new MvcProgrammer()
            {
                Id = prog.Id,
                Name = prog.Name,
                Surname = prog.Surname,
                Age = prog.Age,
                Salary = prog.Salary,
            };
        }

    }
}