using BusinessLogic.IService;
using BusinessLogic.Service;
using DataAccess;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using SchoolManagementApp.Controllers;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;

namespace SchoolManagementApp
{
    public static class UnityConfig
    {
        [System.Obsolete]
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IStudentService, StudentService>();
            container.RegisterType<ICourseService, CourseService>();
            container.RegisterType<ILoginService, LoginService>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            //container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            //container.RegisterType(typeof(IUserStore<>), typeof(UserStore<>));
            //container.RegisterType<HomeController>(new InjectionConstructor());
            //container.RegisterType<StudentController>(new InjectionConstructor());

            container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<HttpContextBase>(
            new InjectionFactory(_ => new HttpContextWrapper(HttpContext.Current)));
            container.RegisterType<IOwinContext>(new InjectionFactory(c => c.Resolve<HttpContextBase>().GetOwinContext()));
            container.RegisterType<IAuthenticationManager>(
                new InjectionFactory(c => c.Resolve<IOwinContext>().Authentication));
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}