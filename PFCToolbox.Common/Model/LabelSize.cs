using System.ComponentModel.DataAnnotations;

namespace PFCToolbox.Common.Model
{
    public partial class LabelSize : DatabaseEntity
    {
        [StringLength(255)]
        public string LabelSizes { get; set; }
    }
}
