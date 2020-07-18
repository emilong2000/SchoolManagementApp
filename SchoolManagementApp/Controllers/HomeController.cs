using BusinessLogic.IService;
using BusinessLogic.Service;
using DomainModel.Models;
using DomainModel.Models.Dtos;
using Microsoft.AspNet.Identity.Owin;
using NLog.Fluent;
using SchoolManagementApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SchoolManagementApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILoginService _service;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public HomeController(LoginService service, ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            _service = service;
            UserManager = userManager;
            SignInManager = signInManager;
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginDto loginDto, string returnUrl)
        {
            var newLogin = new Login();
            var loginmap = AutoMapper.Mapper.Map(loginDto, newLogin);
            var loginResult =_service.Login(loginmap);
            if (loginResult)
            {
                FormsAuthentication.SetAuthCookie(loginDto.Email, true);
                return RedirectToLocal(returnUrl);
            }
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            Session["User"] = User.Identity.Name;
            return RedirectToAction("Index", "Home");
        }
    }
}