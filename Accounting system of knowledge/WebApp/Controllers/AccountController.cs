using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interface;
using WebApp.Infrastructure.Mappers;
using System.Web.Security;
using WebApp.Models;
using BLL.Interface.Services;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class AccountController:Controller
    {
        private readonly ILoginService login;
        public AccountController(ILoginService login)
        {
            this.login = login;
        }
        [HttpGet]
        [Route("Registration")]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpGet]
        [Route("Login")]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Login", Name = "Login")]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = LoginMapper.GetMVCEntity(login.Login(loginModel.MailOrLogin, loginModel.Password));
                    FormsAuthentication.SetAuthCookie(user.Login, true);
                    return RedirectToRoute("Home");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(e.Message, e.Message);
                }
            }

            string errorMessage = GetModelStateErrors(ModelState);

            if (Request.IsAjaxRequest())
                return Json(new { Result = errorMessage });
            return View();
        }
        [HttpPost]
        [Route(Name = "Registration")]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    login.Create(LoginMapper.GetBLLEntity(model));

                    if (Request.IsAjaxRequest())
                        return Json(new { Result = "You have registered!" });
                    return RedirectToRoute("Home");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(e.Message, e.Message);
                }
            }

            string errorMessage = GetModelStateErrors(ModelState);

            if (Request.IsAjaxRequest())
                return Json(new { Result = errorMessage });

            return View();
        }
        [Route("Logout", Name = "Logout")]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToRoute("Home");
        }
        private string GetModelStateErrors(ModelStateDictionary dictionary)
        {
            string errorMessage = string.Empty;

            foreach (ModelState modelState in dictionary.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    errorMessage += error.ErrorMessage + "\n";
                }
            }
            return errorMessage;
        }
    }
}