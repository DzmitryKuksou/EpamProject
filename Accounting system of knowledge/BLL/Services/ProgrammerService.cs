using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Repositories;
using DAL.Interface.DTO;
using BLL.Interface.Entities;
using BLL.Mappers;

namespace BLL.Interface.Services
{
    public class ProgrammerService:IProgrammerService
    {
        private readonly IUnitOfWork uow;
        public ProgrammerService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public BLLProgrammer Get(int id)
        {
            var prog = ProgrammerMapper.GetBLLEntity(uow.Programmers.GetById(id));
            return prog;
        }
        public void UpDate(BLLProgrammer prog)
        {
            uow.Programmers.UpDate(ProgrammerMapper.GetDALEntity(prog));
            uow.Commit();
        }        
    }
}
