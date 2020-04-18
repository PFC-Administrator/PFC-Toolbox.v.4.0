using System.Web.Mvc;

namespace PFC_Toolbox.v._4._0.Controllers
{
    public class LogsController : Controller
    {
        // GET: Logs
        public ActionResult Index()
        {
            ViewBag.Message = "Logs!";

            return View();
        }

        // GET: /Logs/CreatePurchases
        [Authorize] // Restricts the page to logged in users only
        public ActionResult CreatePurchases()
        {
            return View();
        }

        // GET: /Logs/CreateWriteoff
        public ActionResult CreateWriteoffs()
        {
            return View();
        }

        // GET: /Logs/CreateExpirations
        public ActionResult CreateExpirations()
        {
            return View();
        }
    }
}
 