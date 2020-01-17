using System.Configuration;
using System.Web;
using System.Web.Http;
using DataTables;

namespace PFC_Toolbox.v._4._0.Controllers
{
    public class SubdepartmentController : ApiController
    {
        [Route("Maintenance/api/GetSubdepartmentBounds")]
        [HttpGet]
        public IHttpActionResult ProductUpdates(string F04)
        {
            var request = HttpContext.Current.Request;

            using (var db1 = new Database("sqlserver", ConfigurationManager.ConnectionStrings["ToolboxConnection"].ConnectionString))
            {
                var response = new Editor(db1, "SMSSubdepartments", "F04")
                    .Field(new Field("SMSSubdepartments.F04")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Field(new Field("SMSSubdepartments.lowerBound")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Field(new Field("SMSSubdepartments.upperBound")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Field(new Field("SMSSubdepartments.F49")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Field(new Field("SMSSubdepartments.F78")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Field(new Field("SMSSubdepartments.F79")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Field(new Field("SMSSubdepartments.F80")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Field(new Field("SMSSubdepartments.F81")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Field(new Field("SMSSubdepartments.F82")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Field(new Field("SMSSubdepartments.F88")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Field(new Field("SMSSubdepartments.F96")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Field(new Field("SMSSubdepartments.F97")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Field(new Field("SMSSubdepartments.F98")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Field(new Field("SMSSubdepartments.F99")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Field(new Field("SMSSubdepartments.F100")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Field(new Field("SMSSubdepartments.F101")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Field(new Field("SMSSubdepartments.F104")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Field(new Field("SMSSubdepartments.F108")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Field(new Field("SMSSubdepartments.F114")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Field(new Field("SMSSubdepartments.F115")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Field(new Field("SMSSubdepartments.F121")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Field(new Field("SMSSubdepartments.F124")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Field(new Field("SMSSubdepartments.F150")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Field(new Field("SMSSubdepartments.F170")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Field(new Field("SMSSubdepartments.F171")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Field(new Field("SMSSubdepartments.F172")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Field(new Field("SMSSubdepartments.F177")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Field(new Field("SMSSubdepartments.F178")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Field(new Field("SMSSubdepartments.F1022")
                    ).Where(q => q.Where("F04", F04, "="))
                    .Process(request)
                    .Data();

                return Json(response);

            }
        }

        [Route("Reports/api/GetSubdepartmentBounds")]
        [HttpGet]
        public IHttpActionResult ProductUpdates()
        {
            var request = HttpContext.Current.Request;

            using (var db1 = new Database("sqlserver", ConfigurationManager.ConnectionStrings["ToolboxConnection"].ConnectionString))
            {
                var response = new Editor(db1, "SMSSubdepartments", "F04")
                    .Field(new Field("SMSSubdepartments.F04")
                    )
                    .Field(new Field("SMSSubdepartments.F1022")
                    )
                    .Process(request)
                    .Data();

                return Json(response);

            }
        }
    }
}