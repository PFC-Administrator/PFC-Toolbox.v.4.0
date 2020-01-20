using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PFC_Toolbox.v._4._0.Controllers
{
    public class MaintenanceController : Controller
    {
        // GET: Maintenance
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
        public ActionResult ProductUpdates()
        {
            return View();
        }

        // GET: /Maintenance/NewProducts
        public ActionResult NewProducts()
        {
            return View();
        }
    }
}