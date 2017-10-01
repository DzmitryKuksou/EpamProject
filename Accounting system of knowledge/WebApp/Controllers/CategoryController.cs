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
    [Authorize(Roles = "Administrator")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categories;
        public CategoryController(ICategoryService categories)
        {
            this.categories = categories;
        }
        [Route("Categories", Name = "Categories")]
        public ActionResult Categories(string SearchString, int page = 1)
        {
            var mvcCategories = GetAllOrFind(SearchString);

            ViewBag.mvcCategories = mvcCategories;

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Categories");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        [Route("CreateCategory")]
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateCategory", Name = "CreateCategory")]
        public ActionResult CreateCategory(MvcCategory category)
        {
            if (ModelState.IsValid)
            {
                categories.Create(CategoryMapper.GetBLLEntity(category));
                return RedirectToRoute("Categories");
            }

            return View();
        }
        [HttpGet]
        [Route("EditCategory")]
        public ActionResult EditCategory(int id)
        {
            MvcCategory category = CategoryMapper.GetMVCEntity(categories.Get(id));
            return View(category);
        }
        [HttpPost]
        [Route("EditCategory", Name = "EditCategory")]
        public ActionResult EditCategory(MvcCategory category)
        {
            if (ModelState.IsValid)
            {
                categories.Update(CategoryMapper.GetBLLEntity(category));
                return RedirectToRoute("Categories");
            }

            return View();
        }
        [HttpGet]
        [Route("RemoveCategory", Name = "RemoveCategory")]
        public ActionResult RemoveCategory(int id)
        {
            if (ModelState.IsValid)
            {
                categories.Delete(id);
            }

            return RedirectToRoute("Categories");
        }

        private IEnumerable<MvcCategory> GetAllOrFind(string searchString)
        {
            IEnumerable<BLLCategory> allCategories = categories.GetAll();
            List<MvcCategory> mvcCategories = allCategories.Select(c => CategoryMapper.GetMVCEntity(c)).ToList();
            if (!ReferenceEquals(searchString, null) && searchString != "")
            {
                mvcCategories = mvcCategories.Where(s => s.Name.Contains(searchString)).ToList();
            }
            return mvcCategories;
        }
        public ActionResult FindCategories(string term)
        {
            var mvcCategories = categories.Find(term).Select(c => c.Name);

            return Json(mvcCategories.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}