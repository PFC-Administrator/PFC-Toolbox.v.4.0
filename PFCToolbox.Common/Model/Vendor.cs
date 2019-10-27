using System.ComponentModel.DataAnnotations;

namespace PFCToolbox.Common.Model
{
    public partial class Vendor : DatabaseEntity
    {
        [Required]
        public string VendorName { get; set; }
    }
}
