using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interface;
using WebApp.Infrastructure.Mappers;
using WebApp.Models;
using BLL.Interface.Services;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministratorController:Controller
    {
        private readonly ILoginService logins;
        public AdministratorController(ILoginService userService)
        {
            logins = userService;
        }
        [HttpGet]
        [Route("Users")]
        public ActionResult Users()
        {
            ViewBag.mvcLogins = LoginMapper.Map(logins.GetAll());
            ViewBag.Roles = new string[] { "Administrator", "Manager", "User" };
            return View();
        }
        [HttpPost]
        [Route("Users", Name = "Users")]
        public ActionResult Users(List<MvcLogin> Entities)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in Entities)
                {
                    logins.UpDate(LoginMapper.GetBLLEntity(item));
                }
            }
            return Redirect("Users");

        }
        [Route("RemoveUser", Name = "RemoveUser")]
        public ActionResult RemoveUser(int Id)
        {
            logins.Delete(Id);
            return Redirect("Users");
        }
    }
}