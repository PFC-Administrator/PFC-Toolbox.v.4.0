using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Owin;
using PFC_Toolbox.v._4._0.App_Start;
using PFC_Toolbox.v._4._0.Models;
using PFCToolbox.Common.Model;
using PFCToolbox.Data.Context;
using PFCToolbox.Data.Repo;
using PFCToolbox.Service;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PFC_Toolbox.v._4._0
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // set up SimpleInjector for dependency injections
            var container = new Container();
            
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            RegisterOwinDependencies(container);

            // register dbContexts
            container.Register<IPFCToolboxContext, PFCToolboxContext>(Lifestyle.Scoped);

            // register services
            container.Register<IAuxiliaryService, AuxiliaryService>(Lifestyle.Scoped);

            // register repos
            container.Register<IRepo<Location>, Repo<Location>>(Lifestyle.Scoped);
            container.Register<IRepo<Subdepartment>, Repo<Subdepartment>>(Lifestyle.Scoped);
            container.Register<IRepo<Vendor>, Repo<Vendor>>(Lifestyle.Scoped);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void RegisterOwinDependencies(Container container)
        {
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // ApplicationDbContext
            container.Register(() =>
                new ApplicationDbContext(ConfigurationManager.ConnectionStrings["ToolboxConnection"].ConnectionString),
                Lifestyle.Scoped);

            // IUserStore
            container.Register<IUserStore<ApplicationUser>>(() =>
                new UserStore<ApplicationUser>(container.GetInstance<ApplicationDbContext>())
                , Lifestyle.Scoped);

            // UserManager
            container.Register(() =>
                new UserManager<ApplicationUser, string>(new UserStore<ApplicationUser>()),
                Lifestyle.Scoped);

            container.Register<ApplicationUserManager>(Lifestyle.Scoped);

            // SignInManager
            container.Register<SignInManager<ApplicationUser, string>, ApplicationSignInManager>(Lifestyle.Scoped);

            // Verify hack for Authentication Manager
            container.Register(() =>
                container.IsVerifying
                    ? new OwinContext(new Dictionary<string, object>()).Authentication
                    : HttpContext.Current.GetOwinContext().Authentication, Lifestyle.Scoped);
        }
    }
}
