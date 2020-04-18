using System.Web.Mvc;

namespace PFC_Toolbox.v._4._0.Controllers.Administration
{
    public class AdministrationController : Controller
    {
        // GET: Administration
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Administration/ErrorLogs
        public ActionResult ErrorLogs()
        {
            return View();
        }

        // GET: /Administration/Users
        public ActionResult Users()
        {
            return View();
        }
    }
}