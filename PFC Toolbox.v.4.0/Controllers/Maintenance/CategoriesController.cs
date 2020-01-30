using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Web;
using System.Web.Http;
using DataTables;

namespace PFC_Toolbox.v._4._0.Controllers
{
    public class CategoriesController : ApiController
    {
        // GET: Categories
        [Route("api/Categories")]
        [HttpPost]
        public IHttpActionResult CategoryOptions()
        {
            var request = HttpContext.Current.Request;

            using (var db = new Database("sqlserver", ConfigurationManager.ConnectionStrings["ToolboxConnection"].ConnectionString))
            {
                var query = db.Select(
                    "SMSCategories",
                    new[] { "F17", "F1023" },
                    new Dictionary<string, dynamic>() { { "F1943", request.Params["values[ProductUpdates.POS_TAB_F04]"] } }
                );

                dynamic result = new ExpandoObject();
                result.options = new ExpandoObject();
                IDictionary<string, object> d = result.options;
                d["ProductUpdates.OBJ_TAB_F17"] = query.FetchAll();

                return Json(result);
            }
        }

        [Route("api/GetCategories")]
        [HttpGet]
        public IHttpActionResult GetCategories()
        {
            var request = HttpContext.Current.Request;

            using (var db1 = new Database("sqlserver", ConfigurationManager.ConnectionStrings["ToolboxConnection"].ConnectionString))
            {
                var response = new Editor(db1, "SMSCategories", "F17")
                    .Field(new Field("SMSCategories.F17")
                    )
                    .Field(new Field("SMSCategories.F1023")
                    )
                    .Process(request)
                    .Data();

                return Json(response);
            }
        }
    }
}

