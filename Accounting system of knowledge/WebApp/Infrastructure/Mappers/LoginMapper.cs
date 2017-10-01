using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interface.Entities;
using WebApp.Models;

namespace WebApp.Infrastructure.Mappers
{
    public class LoginMapper
    {
        public static BLLLogin GetBLLEntity(MvcLogin login)
        {
            return new BLLLogin()
            {
                Id = login.Id,
                Mail = login.Mail,
                Password = login.Password,
                Login = login.Login,
                Roles = login.Roles,
            };
        }
        public static MvcLogin GetMVCEntity(BLLLogin login)
        {
            return new MvcLogin()
            {
                Id = login.Id,
                Mail = login.Mail,
                Password = login.Password,
                Login = login.Login,
                Roles = login.Roles,
            };
        }
        public static BLLLogin GetBLLEntity(RegisterModel prog)
        {


            BLLLogin result = new BLLLogin
            {
                Id = prog.Id,
                Mail = prog.Mail,
                Login = prog.Login,
                Password = prog.Password,
                Roles = new List<string>() { "User" }
            };

            return result;
        }
        public static IEnumerable<MvcLogin> Map(IEnumerable<BLLLogin> logins)
        {
            var List = new List<MvcLogin>();
            foreach(var item in logins)
            {
                List.Add(GetMVCEntity(item));
            }
            return List;
        }
    }
}