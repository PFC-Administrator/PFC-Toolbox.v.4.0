using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using DataTables;
using PFC_Toolbox.v._4._0.Extensions;
using PFC_Toolbox.v._4._0.Models;

namespace PFC_Toolbox.v._4._0.Controllers
{
    public class PLUController : ApiController
    {
        [Route("api/GetNewPLU")]
        [HttpGet]
        [HttpPost]
        public IHttpActionResult ProductUpdates()
        {
            var request = HttpContext.Current.Request;
            var settings = Properties.Settings.Default;

            using (var db1 = new Database(settings.DbType, settings.DbConnection2))
            {
                var response = new Editor(db1, "OBJ_TAB", "F01")
                    .Field(new Field("OBJ_TAB.F01")
                    .Options(() => db1.Sql("SELECT OBJ_TAB.F01 FROM OBJ_TAB WHERE OBJ_TAB.F01 BETWEEN '0028000000000' AND '0028999900000'").FetchAll())
                    //.Validator(Validation.NotEmpty())
                    )//.Where(q => q.Where("OBJ_TAB.F01", "(SELECT OBJ_TAB.F01 FROM OBJ_TAB WHERE OBJ_TAB.F01 BETWEEN '0028000000000' AND '0028999900000')", "IN", false))
                     .Process(request)
                    .Data();

                return Json(response);
            }
        }
    }
}