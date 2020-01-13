using System.Configuration;
using System.Web;
using System.Web.Http;
using DataTables;

namespace PFC_Toolbox.v._4._0.Controllers
{
    public class UPCController : ApiController
    {
        [Route("Maintenance/api/CheckUPC")]
        [HttpGet]
        public IHttpActionResult ProductUpdates()
        {
            var request = HttpContext.Current.Request;

            using (var db1 = new Database("sqlserver", ConfigurationManager.ConnectionStrings["SMSHostConnection"].ConnectionString))
            {
                var response = new Editor(db1, "OBJ_TAB", "F01")
                    .Field(new Field("OBJ_TAB.F01")
                    )
                    .Process(request)
                    .Data();

                return Json(response);

            }
        }
    }
}