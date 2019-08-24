using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using DataTables;
using PFC_Toolbox.v._4._0.Extensions;
using PFC_Toolbox.v._4._0.Models;

namespace PFC_Toolbox.v._4._0.Controllers
{
    public class RefreshBrandController : ApiController
    {
        [Route("Maintenance/api/RefreshBrand")]
        [HttpGet]
        [HttpPost]
        public IHttpActionResult RefreshBrand()
        {
            var request = HttpContext.Current.Request;
            var settings = Properties.Settings.Default;

            using (var db = new Database(settings.DbType, settings.DbConnection1))
            {
                var query = db.Select(
                    "Brands",
                    new[] { "Brand" },
                    new Dictionary<string, dynamic>() { { "", request.Params["values[ProductUpdates.POS_TAB_F04]"] } }
                );

                dynamic result = new ExpandoObject();
                result.options = new ExpandoObject();
                IDictionary<string, object> d = result.options;
                d["ProductUpdates.OBJ_TAB_F155"] = query.FetchAll();

                return Json(result);
            }
        }
    }
}


/*        [Route("Maintenance/api/RefreshBrand")]
        [HttpGet]
        [HttpPost]
        public IHttpActionResult RefreshBrand()
        {
            var request = HttpContext.Current.Request;
            var settings = Properties.Settings.Default;

            using (var db1 = new Database(settings.DbType, settings.DbConnection1))
            {
                var response = new Editor(db1, "Brands", "Brand")
                    .Field(new Field("Brands.Brand")
                    )
                    .Process(request)
                    .Data();

                dynamic result = new ExpandoObject();
                result.options = new ExpandoObject();
                result.options.Brands = response.data;

                return Json(result);
            }
        }*/
