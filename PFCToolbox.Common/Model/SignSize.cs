using System.ComponentModel.DataAnnotations;

namespace PFCToolbox.Common.Model
{
    public partial class SignSize : DatabaseEntity
    {
        [StringLength(255)]
        public string SignSizes { get; set; }
    }
}
