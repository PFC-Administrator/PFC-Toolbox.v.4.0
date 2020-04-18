using System.Configuration;
using System.Web;
using System.Web.Http;
using DataTables;

namespace PFC_Toolbox.v._4._0.Controllers
{
    public class UserController : ApiController
    {
        [Route("api/GetUsers")]
        [HttpGet]
        [HttpPost]
        public IHttpActionResult GetUsers()
        {
            var request = HttpContext.Current.Request;

            using (var db1 = new Database("sqlserver", ConfigurationManager.ConnectionStrings["ToolboxConnection"].ConnectionString))
            {
                var response = new Editor(db1, "AspNetUsers", "Id")
                    .Field(new Field("AspNetUsers.UserName")
                    )
                    .Field(new Field("AspNetUsers.Email")
                    )
                    .Field(new Field("AspNetUsers.CreatedBy")
                    )
                    .Field(new Field("AspNetUsers.Role")
                    .Options(new Options()
                    .Table("AspNetRoles")
                    .Value("Id")
                    .Label("Name"))
                    )
                    .Field(new Field("AspNetRoles.Id")
                    .Validator(Validation.NotEmpty())
                    )
                    .Field(new Field("AspNetRoles.Name")
                    .Validator(Validation.NotEmpty())
                    )

                    // Joined tables
                    .LeftJoin("AspNetRoles", "AspNetRoles.Id", "=", "AspNetUsers.Role"
                    )

                    .Process(request)
                    .Data();

                return Json(response);
            }
        }

        [Route("api/GetCurrentUserInfo")]
        [HttpGet]
        public IHttpActionResult GetCurrentUserInfo(string currentUser)
        {
            var request = HttpContext.Current.Request;

            using (var db1 = new Database("sqlserver", ConfigurationManager.ConnectionStrings["ToolboxConnection"].ConnectionString))
            {
                var response = new Editor(db1, "AspNetUsers", "Id")
                    .Field(new Field("UserName")
                    )
                    .Field(new Field("Email")
                    )
                    .Field(new Field("CreatedBy")
                    )
                    .Field(new Field("Role")
                    )

                    // Where statement
                    .Where(q => q.Where("UserName", currentUser, "="))

                    .Process(request)
                    .Data();

                return Json(response);
            }
        }
    }
}