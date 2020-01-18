using System.Configuration;
using System.Web;
using System.Web.Http;
using DataTables;
using PFC_Toolbox.v._4._0.Models;

namespace PFC_Toolbox.v._4._0.Controllers
{
    public class WriteoffsController : ApiController
    {
        [Route("api/Writeoffs")]
        [HttpGet]
        [HttpPost]
        public IHttpActionResult Writeoffs()
        {
            var request = HttpContext.Current.Request;

            using (var db = new Database("sqlserver", ConfigurationManager.ConnectionStrings["ToolboxConnection"].ConnectionString))
            {
                var response = new Editor(db, "Writeoffs", "writeoffID")
                    .Model<WriteoffsModel>()
                    .Field(new Field("Writeoffs.writeoffID")
                    .Validator(Validation.NotEmpty())
                    )
                    .Field(new Field("Writeoffs.writeoffcode")
                    )
                    .Field(new Field("Writeoffs.writeoffitemname")
                    .Validator(Validation.NotEmpty())
                    )
                    .Field(new Field("Writeoffs.writeoffquantity")
                    .Validator(Validation.NotEmpty())
                    .Validator(Validation.Numeric())
                    )
                    .Field(new Field("Writeoffs.writeoffunitprice")
                    .Validator(Validation.NotEmpty())
                    .Validator(Validation.Numeric())
                    )
                    .Field(new Field("Writeoffs.writeofftotalprice")
                    .Validator(Validation.NotEmpty())
                    .Validator(Validation.Numeric())
                    )
                    .Field(new Field("Writeoffs.locationID")
                    .Options(new Options()
                    .Table("Locations")
                    .Value("locationID")
                    .Label("locationName"))
                    .Validator(Validation.NotEmpty())
                    )
                    .Field(new Field("Locations.locationname")
                    .Validator(Validation.NotEmpty())
                    )
                    .Field(new Field("Subdepartments.subdepartmentname")
                    .Validator(Validation.NotEmpty())
                    )
                    .Field(new Field("Writeoffs.subdepartmentID")
                    .Options(new Options()
                    .Table("Subdepartments")
                    .Value("subdepartmentID")
                    .Label("subdepartmentName"))
                    .Validator(Validation.NotEmpty())
                    )
                    .Field(new Field("Writeoffs.writeoffmemo")
                    )
                    .Field(new Field("Writeoffs.CreatedBy")
                    .Validator(Validation.NotEmpty())
                    )
                    .Field(new Field("Writeoffs.DateCreated")
                    .Validator(Validation.NotEmpty())
                    )

                    // Joined tables
                    .LeftJoin("Locations", "Locations.locationID", "=", "Writeoffs.locationID"
                    )
                    .LeftJoin("Subdepartments", "Subdepartments.subdepartmentID", "=", "Writeoffs.subdepartmentID"
                    )
                    .Where(q => q.Where("Writeoffs.DateCreated", "DATEADD(year, -1, GETDATE())", ">=", false))
                     .Process(request)
                    .Data();

                return Json(response);
            }
        }
    }
}