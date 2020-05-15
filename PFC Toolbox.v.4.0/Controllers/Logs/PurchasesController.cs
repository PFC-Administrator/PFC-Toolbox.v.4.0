using System.Configuration;
using System.Web;
using System.Web.Http;
using DataTables;
using PFC_Toolbox.v._4._0.Models;

namespace PFC_Toolbox.v._4._0.Controllers
{
    public class PurchasesController : ApiController
    {
        [Route("api/Purchases")]
        [HttpGet]
        [HttpPost]
        public IHttpActionResult Purchases()
        {
            var request = HttpContext.Current.Request;

            using (var db = new Database("sqlserver", ConfigurationManager.ConnectionStrings["ToolboxConnection"].ConnectionString))
            {
                var response = new Editor(db, "Purchases", "purchaseID")
                    .Model<PurchasesModel>()
                    .Field(new Field("Purchases.purchaseID")
                    .Validator(Validation.NotEmpty())
                    )
                    .Field(new Field("Purchases.invoicenumber")
                    .Validator(Validation.NotEmpty(new ValidationOpts
                    {
                        Message = "Required"
                    }))
                    )
                    .Field(new Field("Purchases.purchasedate")
                    .Validator(Validation.NotEmpty(new ValidationOpts
                    {
                        Message = "Required"
                    }))
                    .Validator(Validation.DateFormat("M/d/yyyy"))
                    .GetFormatter(Format.DateTime("M/d/yyyy", "M/d/yyyy"))
                    .SetFormatter(Format.DateTime("M/d/yyyy", "M/d/yyyy"))
                    )
                    .Field(new Field("Purchases.vendorID")
                    .Options(new Options()
                    .Table("SMSVendors")
                    .Value("F27")
                    .Label("F334"))
                    .Validator(Validation.NotEmpty(new ValidationOpts
                    {
                        Message = "Required"
                    }))
                    )
                    .Field(new Field("SMSVendors.F334")
                    .Validator(Validation.NotEmpty())
                    )
                    .Field(new Field("Purchases.purchaseamount")
                    .Validator(Validation.NotEmpty(new ValidationOpts
                    {
                        Message = "Required"
                    }))
                    .Validator(Validation.Numeric())
                    )
                    .Field(new Field("Purchases.subdepartmentID")
                    .Options(new Options()
                    .Table("Subdepartments")
                    .Value("subdepartmentID")
                    .Label("subdepartmentName"))
                    .Validator(Validation.NotEmpty(new ValidationOpts
                    {
                        Message = "Required"
                    }))
                    )
                    .Field(new Field("Subdepartments.subdepartmentname")
                    .Validator(Validation.NotEmpty())
                    )
                    .Field(new Field("Purchases.locationID")
                    .Options(new Options()
                    .Table("Locations")
                    .Value("locationID")
                    .Label("locationName"))
                    .Validator(Validation.NotEmpty(new ValidationOpts
                    {
                        Message = "Required"
                    }))
                    )
                    .Field(new Field("Locations.locationname")
                    .Validator(Validation.NotEmpty())
                    )
                    .Field(new Field("Purchases.purchasereconciled")
                    .Validator(Validation.NotEmpty())
                    )
                    .Field(new Field("Purchases.purchasememo")
                    )
                    .Field(new Field("Purchases.CreatedBy")
                    .Validator(Validation.NotEmpty(new ValidationOpts
                    {
                        Message = "Required"
                    }))
                    )
                    .Field(new Field("Purchases.DateCreated")
                    .Validator(Validation.NotEmpty())
                    )
                    /////////
                    .Field(new Field("Purchases.purchaseamount2")
                    .SetFormatter(Format.NullEmpty())
                    )
                    .Field(new Field("Purchases.subdepartmentID2")
                    .Options(new Options()
                    .Table("Subdepartments")
                    .Value("subdepartmentID")
                    .Label("subdepartmentName"))
                    )
                    .Field(new Field("Purchases.purchaseamount3")
                    .SetFormatter(Format.NullEmpty())
                    )
                    .Field(new Field("Purchases.subdepartmentID3")
                    .Options(new Options()
                    .Table("Subdepartments")
                    .Value("subdepartmentID")
                    .Label("subdepartmentName"))
                    )
                    .Field(new Field("Purchases.purchaseamount4")
                    .SetFormatter(Format.NullEmpty())
                    )
                    .Field(new Field("Purchases.subdepartmentID4")
                    .Options(new Options()
                    .Table("Subdepartments")
                    .Value("subdepartmentID")
                    .Label("subdepartmentName"))
                    )
                    .Field(new Field("Purchases.purchaseamount5")
                    .SetFormatter(Format.NullEmpty())
                    )
                    .Field(new Field("Purchases.subdepartmentID5")
                    .Options(new Options()
                    .Table("Subdepartments")
                    .Value("subdepartmentID")
                    .Label("subdepartmentName"))
                    )
                    .Field(new Field("Purchases.purchaseamount6")
                    .SetFormatter(Format.NullEmpty())
                    )
                    .Field(new Field("Purchases.subdepartmentID6")
                    .Options(new Options()
                    .Table("Subdepartments")
                    .Value("subdepartmentID")
                    .Label("subdepartmentName"))
                    )
                    .Field(new Field("Purchases.purchaseamount7")
                    .SetFormatter(Format.NullEmpty())
                    )
                    .Field(new Field("Purchases.subdepartmentID7")
                    .Options(new Options()
                    .Table("Subdepartments")
                    .Value("subdepartmentID")
                    .Label("subdepartmentName"))
                    )
                    .Field(new Field("Purchases.purchaseamount8")
                    .SetFormatter(Format.NullEmpty())
                    )
                    .Field(new Field("Purchases.subdepartmentID8")
                    .Options(new Options()
                    .Table("Subdepartments")
                    .Value("subdepartmentID")
                    .Label("subdepartmentName"))
                    )
                    .Field(new Field("Purchases.purchaseamount9")
                    .SetFormatter(Format.NullEmpty())
                    )
                    .Field(new Field("Purchases.subdepartmentID9")
                    .Options(new Options()
                    .Table("Subdepartments")
                    .Value("subdepartmentID")
                    .Label("subdepartmentName"))
                    )
                    .Field(new Field("Purchases.purchaseamount10")
                    .SetFormatter(Format.NullEmpty())
                    )
                    .Field(new Field("Purchases.subdepartmentID10")
                    .Options(new Options()
                    .Table("Subdepartments")
                    .Value("subdepartmentID")
                    .Label("subdepartmentName"))
                    )
                    .Field(new Field("Purchases.purchaseamount11")
                    .SetFormatter(Format.NullEmpty())
                    )
                    .Field(new Field("Purchases.subdepartmentID11")
                    .Options(new Options()
                    .Table("Subdepartments")
                    .Value("subdepartmentID")
                    .Label("subdepartmentName"))
                    )
                    .Field(new Field("Purchases.purchaseamount12")
                    .SetFormatter(Format.NullEmpty())
                    )
                    .Field(new Field("Purchases.subdepartmentID12")
                    .Options(new Options()
                    .Table("Subdepartments")
                    .Value("subdepartmentID")
                    .Label("subdepartmentName"))
                    )
                    .Field(new Field("Purchases.purchaseamount13")
                    .SetFormatter(Format.NullEmpty())
                    )
                    .Field(new Field("Purchases.subdepartmentID13")
                    .Options(new Options()
                    .Table("Subdepartments")
                    .Value("subdepartmentID")
                    .Label("subdepartmentName"))
                    )
                    .Field(new Field("Purchases.purchaseamount14")
                    .SetFormatter(Format.NullEmpty())
                    )
                    .Field(new Field("Purchases.subdepartmentID14")
                    .Options(new Options()
                    .Table("Subdepartments")
                    .Value("subdepartmentID")
                    .Label("subdepartmentName"))
                    )
                    .Field(new Field("Purchases.purchaseamount15")
                    .SetFormatter(Format.NullEmpty())
                    )
                    .Field(new Field("Purchases.subdepartmentID15")
                    .Options(new Options()
                    .Table("Subdepartments")
                    .Value("subdepartmentID")
                    .Label("subdepartmentName"))
                    )
                    .Field(new Field("Purchases.purchaseamount16")
                    .SetFormatter(Format.NullEmpty())
                    )
                    .Field(new Field("Purchases.subdepartmentID16")
                    .Options(new Options()
                    .Table("Subdepartments")
                    .Value("subdepartmentID")
                    .Label("subdepartmentName"))
                    )
                    .Field(new Field("Purchases.purchaseamount17")
                    .SetFormatter(Format.NullEmpty())
                    )
                    .Field(new Field("Purchases.subdepartmentID17")
                    .Options(new Options()
                    .Table("Subdepartments")
                    .Value("subdepartmentID")
                    .Label("subdepartmentName"))
                    )
                    .Field(new Field("Purchases.purchaseamount18")
                    .SetFormatter(Format.NullEmpty())
                    )
                    .Field(new Field("Purchases.subdepartmentID18")
                    .Options(new Options()
                    .Table("Subdepartments")
                    .Value("subdepartmentID")
                    .Label("subdepartmentName"))
                    )
                    .Field(new Field("Purchases.purchaseamount19")
                    .SetFormatter(Format.NullEmpty())
                    )
                    .Field(new Field("Purchases.subdepartmentID19")
                    .Options(new Options()
                    .Table("Subdepartments")
                    .Value("subdepartmentID")
                    .Label("subdepartmentName"))
                    )
                    .Field(new Field("Purchases.purchaseamount20")
                    .SetFormatter(Format.NullEmpty())
                    )
                    .Field(new Field("Purchases.subdepartmentID20")
                    .Options(new Options()
                    .Table("Subdepartments")
                    .Value("subdepartmentID")
                    .Label("subdepartmentName"))
                    )
                    /////////
                    // Joined tables
                    .LeftJoin("Locations", "Locations.locationID", "=", "Purchases.locationID"
                    )
                    .LeftJoin("Subdepartments", "Subdepartments.subdepartmentID", "=", "Purchases.subdepartmentID"
                    )
                    .LeftJoin("SMSVendors", "SMSVendors.F27", "=", "Purchases.vendorID"
                    )

                    // Where statements
                    .Where(q => q.Where("PurchaseID", "(SELECT TOP 3000 PurchaseID FROM Purchases ORDER BY PurchaseID DESC)", "IN", false))
                     //.Where( q => q.Where("Purchases.purchasedate", "DATEADD(year, -1, GETDATE())", ">=", false))
                     .Process(request)
                    .Data();

                return Json(response);
            }
        }

        // GET: Vendors
        [Route("api/GetVendors")]
        [HttpGet]
        public IHttpActionResult GetVendors()
        {
            var request = HttpContext.Current.Request;

            using (var db1 = new Database("sqlserver", ConfigurationManager.ConnectionStrings["ToolboxConnection"].ConnectionString))
            {
                var response = new Editor(db1, "SMSVendors", "F27")
                    .Field(new Field("SMSVendors.F334")
                    )
                    .Process(request)
                    .Data();

                return Json(response);
            }
        }

        // GET: AccountingSubdepartments
        [Route("api/GetAccountingSubdepartments")]
        [HttpGet]
        public IHttpActionResult GetSubdepartments()
        {
            var request = HttpContext.Current.Request;

            using (var db1 = new Database("sqlserver", ConfigurationManager.ConnectionStrings["ToolboxConnection"].ConnectionString))
            {
                var response = new Editor(db1, "Subdepartments", "SubdepartmentID")
                    .Field(new Field("Subdepartments.SubdepartmentID")
                    )
                    .Field(new Field("Subdepartments.SubdepartmentName")
                    )
                    .Process(request)
                    .Data();

                return Json(response);
            }
        }
    }
}