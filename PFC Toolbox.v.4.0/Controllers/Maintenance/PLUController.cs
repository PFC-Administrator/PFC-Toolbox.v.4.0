using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using DataTables;
using Newtonsoft.Json;
using PFC_Toolbox.v._4._0.Extensions;
using PFC_Toolbox.v._4._0.Models;

namespace PFC_Toolbox.v._4._0.Controllers
{
    public class PLUController : ApiController
    {
        [Route("Maintenance/api/GetNewPLU")]
        [HttpGet]
        [HttpPost]
        public IHttpActionResult ProductUpdates(string lowerBound, string upperBound)
        {
            var request = HttpContext.Current.Request;

            using (var db1 = new Database("sqlserver", ConfigurationManager.ConnectionStrings["SMSHostConnection"].ConnectionString))
            {
                var response = new Editor(db1, "OBJ_TAB", "F01")
                    .Field(new Field("OBJ_TAB.F01")
                    ).Where(q => q.Where("OBJ_TAB.F01", "(SELECT OBJ_TAB.F01 FROM OBJ_TAB WHERE OBJ_TAB.F01 BETWEEN '" + lowerBound + "' AND '" + upperBound + "')", "IN", false))
                     .Process(request)
                     .Data();

                return Json(response);
            }
        }
    }
}