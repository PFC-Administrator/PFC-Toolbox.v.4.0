using System.ComponentModel.DataAnnotations;

namespace PFCToolbox.Common.Model
{
    public partial class SMSCategory : DatabaseEntity
    {
        [StringLength(30)]
        public string F1023 { get; set; }

        [StringLength(40)]
        public string F1943 { get; set; }

        [StringLength(30)]
        public string F1022 { get; set; }
    }
}
