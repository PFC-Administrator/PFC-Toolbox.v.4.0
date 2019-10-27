using PFCToolbox.Common.Model;
using PFCToolbox.Data.Context;
using PFCToolbox.Data.Repo;
using PFCToolbox.Service;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
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
    }
}
