using System.ComponentModel.DataAnnotations;

namespace PFCToolbox.Common.Model
{
    public partial class SMSVendor : DatabaseEntity
    {
        [Key]
        [StringLength(14)]
        public new string ID { get; set; } // new property that overrides int ID from DatabaseEntity

        [StringLength(40)]
        public string F334 { get; set; }
    }
}
