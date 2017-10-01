using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BLL.Interface;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.Repositories;
using DAL.Interface.DTO;
using DAL.Concrete;
using ORM;
using DAL.Mappers;

namespace ConsoleApplication1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Accountimg_system_of_knowledgeEntities f = new Accountimg_system_of_knowledgeEntities();
            UnitOfWork uow = new UnitOfWork(f);
            LoginService b = new LoginService(uow);
            BLLLogin a = new BLLLogin() {
                Login = "user",
                Password = "sss123",
                Mail = "mail",
            };
            b.Create(a);

        }
    }
}
