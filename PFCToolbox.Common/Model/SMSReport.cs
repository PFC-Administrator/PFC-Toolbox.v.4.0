using System.ComponentModel.DataAnnotations;

namespace PFCToolbox.Common.Model
{
    public partial class SMSReport : DatabaseEntity
    {
        [StringLength(30)]
        public string F1024 { get; set; }
    }
}
