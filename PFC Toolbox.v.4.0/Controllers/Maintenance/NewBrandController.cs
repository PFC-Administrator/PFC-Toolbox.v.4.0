using System.Configuration;
using System.Web;
using System.Web.Http;
using DataTables;

namespace PFC_Toolbox.v._4._0.Controllers
{
    public class NewBrandController : ApiController
    {
        [Route("Maintenance/api/CreateNewBrand")]
        [HttpGet]
        [HttpPost]
        public IHttpActionResult ProductUpdates([FromBody] string brand)
        {
            var request = HttpContext.Current.Request;

            using (var db1 = new Database("sqlserver", ConfigurationManager.ConnectionStrings["ToolboxConnection"].ConnectionString))
            {
                var response = new Editor(db1, "Brands", "Brand")
                    .Field(new Field("Brands.Brand")
                    )
                    .Process(request)
                    .Data();

                return Json(response);
            }
        }
    }
}