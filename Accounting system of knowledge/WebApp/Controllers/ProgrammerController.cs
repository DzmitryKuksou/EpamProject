using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interface;
using WebApp.Infrastructure.Mappers;
using System.Web.Security;
using WebApp.Models;
using BLL.Interface.Services;
using BLL.Interface.Entities;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    [Authorize]
    public class ProgrammerController:Controller
    {
        private readonly IProgrammerService programmers;
        private readonly ILoginService logins;
        private readonly ICategoryService categories;
        public ProgrammerController(IProgrammerService programmers, ILoginService logins, ICategoryService categories)
        {
            this.programmers = programmers;
            this.logins = logins;
            this.categories = categories;
        }
        //[Route("User", Name = "User")]
        //public ActionResult UserProgrammer(int id)
        //{

        //}
        //public ActionResult UserSpheres(int id)
        //{
        //}
        //[HttpGet]
        //[Route("Edit")]
        //public ActionResult Edit()
        //{

        //    return View();
        //}
        [HttpPost]
        [Route("Edit", Name = "Edit")]
        public ActionResult Edit(MvcProgrammer model)
        {
            if (ModelState.IsValid)
            {
                programmers.UpDate(ProgrammerMapper.GetBLLEntity(model));
            }

            return RedirectToRoute("User");
        }
        public ActionResult UserDetails(int id)
        {
            return Json(programmers.Get(id), JsonRequestBehavior.AllowGet);
        }

    }
}