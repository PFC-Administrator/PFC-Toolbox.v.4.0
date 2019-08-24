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
    public class CategoriesController : ApiController
    {
        [Route("api/Categories")]
        [HttpPost]
        public IHttpActionResult CategoryOptions()
            {
            var request = HttpContext.Current.Request;
                var settings = Properties.Settings.Default;
            
                using (var db = new Database(settings.DbType, settings.DbConnection1))
                    {
                        var query = db.Select(
                            "SMSCategories",
                            new[] { "F17", "F1023"},
                            new Dictionary<string, dynamic>() { { "F1943", request.Params["values[ProductUpdates.POS_TAB_F04]"] } }
                        );
                
                        dynamic result = new ExpandoObject();
                        result.options = new ExpandoObject();
                        IDictionary<string, object> d = result.options;
                        d["ProductUpdates.OBJ_TAB_F17"] = query.FetchAll();
                
                    return Json(result);
                    }
                }
    }
}

