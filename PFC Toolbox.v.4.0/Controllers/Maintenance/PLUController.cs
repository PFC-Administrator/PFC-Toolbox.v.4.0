using System.Configuration;
using System.Web;
using System.Web.Http;
using DataTables;

namespace PFC_Toolbox.v._4._0.Controllers
{
    public class PLUController : ApiController
    {
        // GET: PLUs -- get all PLU/UPCs within specified range.
        [Route("api/GetPLUUPCs")]
        [HttpGet]
        [HttpPost]
        public IHttpActionResult ProductUpdates(string lowerBound, string upperBound, string lowerBound2, string upperBound2)
        {
            var request = HttpContext.Current.Request;

            using (var db1 = new Database("sqlserver", ConfigurationManager.ConnectionStrings["SMSHostConnection"].ConnectionString))
            {
                var response = new Editor(db1, "OBJ_TAB", "F01")
                    .Field(new Field("OBJ_TAB.F01")
                    ).Where(q => q.Where("OBJ_TAB.F01", "(SELECT OBJ_TAB.F01 FROM OBJ_TAB WHERE OBJ_TAB.F01 BETWEEN '" + lowerBound + "' AND '" + upperBound + "' OR OBJ_TAB.F01 BETWEEN '" + lowerBound2 + "' AND '" + upperBound2 + "')", "IN", false))
                     .Process(request)
                     .Data();

                return Json(response);
            }
        }

        // GET: PLUs -- add new reference UPC.
        [Route("api/GetReferenceUPCs")]
        [HttpGet]
        public IHttpActionResult GetReferenceUPCs()
        {
            var request = HttpContext.Current.Request;

            using (var db1 = new Database("sqlserver", ConfigurationManager.ConnectionStrings["ToolboxConnection"].ConnectionString))
            {
                var response = new Editor(db1, "ReferenceUPCs", "F01")
                    .Field(new Field("ReferenceUPCs.F01")
                    )
                    .Process(request)
                    .Data();

                return Json(response);
            }
        }

        // POST: PLUs -- add new reference UPC.
        [Route("api/CreateReferenceUPC")]
        [HttpPost]
        public IHttpActionResult CreateReferenceUPC([FromBody] string F01)
        {
            var request = HttpContext.Current.Request;

            using (var db1 = new Database("sqlserver", ConfigurationManager.ConnectionStrings["ToolboxConnection"].ConnectionString))
            {
                var response = new Editor(db1, "ReferenceUPCs", "F01")
                    .Field(new Field("ReferenceUPCs.F01")
                    )
                    .Process(request)
                    .Data();

                return Json(response);
            }
        }
    }
}