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
using Microsoft.AspNet.Identity;

namespace WebApp.Controllers
{
    public class SphereController:Controller
    {
        private readonly ILoginService programmers;
        private readonly ISphereService spheres;
        private readonly ICategoryService categories;
        public SphereController(ILoginService programmers, ISphereService spheres, ICategoryService categories)
        {
            this.programmers = programmers;
            this.spheres = spheres;
            this.categories = categories;
        }
        [Route("YourSpheres")]
        public ActionResult Index()
        {
            var id = Convert.ToInt16(User.Identity.GetUserId());
            var userSpheres = CategoryMapper.Map(programmers.GetUserSpheres(id));

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Spheres");
            }
            else
            {
                return View();
            }
        }
        //[HttpPost]
        //[Route("YourSkills", Name = "UserSkills")]
        //public ActionResult Index(List<MvcCategory> Entities)
        //{
        //    var id = Convert.ToInt16(User.Identity.GetUserId());
        //    programmers.UpdateProgrammerSpheres(id, CategoryMapper.Map(Entities));
        //    return Redirect();
        //}
        [Authorize(Roles = "Administrator")]
        [Route("Spheres", Name = "Spheres")]
        public ActionResult Skills(string FindSphere, string FindCategory, int page = 1)
        {
            var mvcCategories = FindSpheres(FindSphere, FindCategory);
            var categoryNames = new List<string>();

            foreach (var item in categories.GetAll())
            {
                categoryNames.Add(item.Name);
            }
            ViewBag.Categories = categoryNames;
            ViewBag.FindSphere = FindSphere;
            ViewBag.FindCategory = FindCategory;
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        [Route("CreateSphere")]
        public ActionResult CreateSkill(string category = "")
        {
            IEnumerable<BLLCategory> allCategories = categories.GetAll();
            List<string> mvcCategories = allCategories.Select(c => c.Name).ToList();
            ViewBag.Categories = mvcCategories;
            ViewBag.Category = category;
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [Route("CreateSphere", Name = "CreateSphere")]
        public ActionResult CreateSphere(MvcSphere sphere)
        {
            if (ModelState.IsValid)
            {
                spheres.Create(SphereMapper.GetBLLEntity(sphere));
                return RedirectToRoute("Spheres");
            }
            return View();
        }
        [Authorize(Roles = "Administrator")]
        [Route("RemoveSphere", Name = "RemoveSphere")]
        public ActionResult RemoveSphere(int id)
        {
            if (ModelState.IsValid)
            {
                spheres.Delete(id);
            }
            return RedirectToRoute("Spheres");
        }
        private List<MvcCategory> FindSpheres(string sphere, string category)
        {
            var mvcCategories = CategoryMapper.Map(categories.GetAll());

            if (!ReferenceEquals(category, null) && category != "")
            {
                mvcCategories = mvcCategories.Where(s => s.Name == category).ToList();
            }

            if (!ReferenceEquals(sphere, null) && sphere != "")
            {
                foreach (var item in mvcCategories)
                {
                    item.Sphere = item.Sphere.Where(s => s.Name.Contains(sphere)).ToList();
                }
            }

            return mvcCategories.Where(c => c.Sphere.Count > 0).ToList();
        }
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        [Route("EditSphere")]
        public ActionResult EditSphere(int id)
        {
            MvcSphere sphere = SphereMapper.GetMVCEntity(spheres.Get(id));

            IEnumerable<BLLCategory> allCategories = categories.GetAll();
            List<string> mvcCategories = allCategories.Select(c => c.Name).ToList();
            ViewBag.Categories = mvcCategories;

            return View(sphere);
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [Route("EditSphere", Name = "EditSphere")]
        public ActionResult EditSphere(MvcSphere sphere)
        {
            if (ModelState.IsValid)
            {
                spheres.UpDate(SphereMapper.GetBLLEntity(sphere));
                return RedirectToRoute("Spheres");
            }
            return View();
        }

    }
}