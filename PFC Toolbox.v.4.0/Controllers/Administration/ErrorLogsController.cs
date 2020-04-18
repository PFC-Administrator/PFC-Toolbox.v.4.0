using System.Configuration;
using System.Web;
using System.Web.Http;
using DataTables;

namespace PFC_Toolbox.v._4._0.Controllers
{
    public class ErrorLogsController : ApiController
    {
        [Route("api/GetErrorLogs")]
        [HttpGet]
        [HttpPost]
        public IHttpActionResult GetErrorLogs()
        {
            var request = HttpContext.Current.Request;

            using (var db1 = new Database("sqlserver", ConfigurationManager.ConnectionStrings["ToolboxConnection"].ConnectionString))
            {
                var response = new Editor(db1, "ELMAH_error", "ErrorId")
                    .Field(new Field("ELMAH_error.Host")
                    )
                    .Field(new Field("ELMAH_error.StatusCode")
                    )
                    .Field(new Field("ELMAH_error.Type")
                    )
                    .Field(new Field("ELMAH_error.Message")
                    )
                    .Field(new Field("ELMAH_error.User")
                    )
                    .Field(new Field("ELMAH_error.TimeUtc")
                    )

                    .Process(request)
                    .Data();

                return Json(response);
            }
        }
    }
}