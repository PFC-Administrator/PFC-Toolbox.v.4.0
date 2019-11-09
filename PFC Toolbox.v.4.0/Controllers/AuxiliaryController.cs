using PFCToolbox.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PFC_Toolbox.v._4._0.Controllers
{
    public class AuxiliaryController : Controller
    {
        private readonly IAuxiliaryService _auxService;

        public AuxiliaryController(IAuxiliaryService auxSvc)
        {
            _auxService = auxSvc;
        }

        // GET: Auxiliary
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // GET: vendor list
        [HttpGet]
        public ActionResult ListVendors()
        {
            var model = _auxService.GetListOfVendors();

            return View(model);
        }
    }
}