using System.ComponentModel.DataAnnotations;

namespace PFCToolbox.Common.Model
{
    public partial class SMSSubdepartment : DatabaseEntity
    {
        [StringLength(30)]
        public string F1022 { get; set; }
    }
}
