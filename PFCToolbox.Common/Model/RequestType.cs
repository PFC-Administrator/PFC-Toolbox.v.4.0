using System.ComponentModel.DataAnnotations;

namespace PFCToolbox.Common.Model
{
    public partial class RequestType : DatabaseEntity
    {
        [StringLength(255)]
        public string RequestName { get; set; }

        [StringLength(255)]
        public string RequestDescription { get; set; }

        public bool? Promotion { get; set; }
    }
}
