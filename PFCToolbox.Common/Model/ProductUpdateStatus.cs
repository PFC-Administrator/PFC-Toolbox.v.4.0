using System.ComponentModel.DataAnnotations;

namespace PFCToolbox.Common.Model
{
    public partial class ProductUpdateStatus : DatabaseEntity
    {
        [StringLength(255)]
        public string ProductUpdateStatusDescription { get; set; } // appending Description to name to differentiate property from the class itself
    }
}
