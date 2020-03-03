using System.Web.Mvc;

namespace PFC_Toolbox.v._4._0.Controllers
{
    public class MaintenanceController : Controller
    {
        // GET: Maintenance
        [Authorize] // Restricts the page to logged in users only
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Maintenance/ProductMaintenance
        [Authorize] // Restricts the page to logged in users only
        public ActionResult ProductMaintenance()
        {
            return View();
        }

        // GET: /Maintenance/ProductUpdates
        [Authorize] // Restricts the page to logged in users only
        public ActionResult ProductUpdates()
        {
            return View();
        }

        // GET: /Maintenance/NewProducts
        [Authorize] // Restricts the page to logged in users only
        public ActionResult NewProducts()
        {
            return View();
        }
    }
}