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
    public class NewBrandController : ApiController
    {
        [Route("Maintenance/api/CreateNewBrand")]
        [HttpGet]
        [HttpPost]
        public IHttpActionResult ProductUpdates()
        {
            var request = HttpContext.Current.Request;
            var settings = Properties.Settings.Default;

            using (var db1 = new Database(settings.DbType, settings.DbConnection1))
            {
                var response = new Editor(db1, "Brands", "Brand")
                    .Field(new Field("Brand")
                    )
                     .Process(request)
                    .Data();

                return Json(response);

            }
        }
    }
}