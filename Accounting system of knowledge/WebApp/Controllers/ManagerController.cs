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

namespace MvcApp.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerController : Controller
    {
        private readonly ILoginService logins;
        private readonly ISphereService sphereService;
        public ManagerController(ILoginService logins, ISphereService sphereService)
        {
            this.logins = logins;
            this.sphereService = sphereService;
        }
       [Route("Manage", Name = "Manage")]
        public ActionResult Index(IList<string> selector = null, int page = 1)
        {
            var userList = SphereMapper.Map(sphereService.RateProgrammers(selector)).ToList();

            ViewBag.Spheres = (userList.First().Spheres.Select(s => s.Name)).ToArray();
            ViewBag.AllSkills = (sphereService.GetAll().Select(s => s.Name)).ToArray();
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Users");
            }
            else
            {
                return View();
            }
        }
        public ActionResult UserListPdf(IList<string> spheres)
        {
            ViewBag.List = SphereMapper.Map(sphereService.RateProgrammers(spheres)).Take(20).ToList();

            return View();
        }
    }
}