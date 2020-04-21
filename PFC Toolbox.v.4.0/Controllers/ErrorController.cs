using System.Web.Mvc;

namespace PFC_Toolbox.v._4._0.Controllers
{
    public class ErrorController : Controller
    {
        public ViewResult Index()
        {
            return View("Error");
        }

        public ViewResult Error()
        {
            return View("Error");
        }

        public ViewResult NotFound()
        {
            Response.StatusCode = 404;
            return View("NotFound");
        }

        public ViewResult AccessDenied()
        {
            return View("AccessDenied");
        }
    }
}