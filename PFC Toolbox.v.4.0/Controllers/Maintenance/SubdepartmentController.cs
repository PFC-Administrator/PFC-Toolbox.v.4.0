using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using DataTables;
using Newtonsoft.Json;
using PFC_Toolbox.v._4._0.Extensions;
using PFC_Toolbox.v._4._0.Models;

namespace PFC_Toolbox.v._4._0.Controllers
{
    public class SubdepartmentController : ApiController
    {
        [Route("Maintenance/api/GetSubdepartmentBounds")]
        [HttpGet]
        [HttpPost]
        public IHttpActionResult ProductUpdates(string subdepartment)
        {
            var request = HttpContext.Current.Request;
            var settings = Properties.Settings.Default;

            using (var db1 = new Database(settings.DbType, settings.DbConnection1))
            {
                var response = new Editor(db1, "SMSSubdepartments", "F04")
                    .Field(new Field("SMSSubdepartments.lowerBound")
                    ).Where(q => q.Where("F04", subdepartment, "="))
                    .Field(new Field("SMSSubdepartments.upperBound")
                    ).Where(q => q.Where("F04", subdepartment, "="))
                     .Process(request)
                    .Data();

                return Json(response);

            }
        }
    }
}