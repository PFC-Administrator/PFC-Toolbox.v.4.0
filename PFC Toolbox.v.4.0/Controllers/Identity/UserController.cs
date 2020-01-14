using System;
using System.Configuration;
using System.Web;
using System.Web.Http;
using DataTables;

namespace PFC_Toolbox.v._4._0.Controllers
{
    public class UserController : ApiController
    {
        [Route("Maintenance/api/GetUserInfo")]
        [HttpGet]
        public IHttpActionResult GetUserInfo(string currentUser)
        {
            var request = HttpContext.Current.Request;
            //var currentUser = User.Identity.Name;

            using (var db1 = new Database("sqlserver", ConfigurationManager.ConnectionStrings["ToolboxConnection"].ConnectionString))
            {
                var response = new Editor(db1, "AspNetUsers", "Id")
                    .Field(new Field("UserName")
                    ).Where(q => q.Where("UserName", currentUser, "="))
                    .Field(new Field("Email")
                    ).Where(q => q.Where("UserName", currentUser, "="))
                    .Field(new Field("CreatedBy")
                    ).Where(q => q.Where("UserName", currentUser, "="))
                    .Process(request)
                    .Data();

                return Json(response);

            }
        }
    }
}