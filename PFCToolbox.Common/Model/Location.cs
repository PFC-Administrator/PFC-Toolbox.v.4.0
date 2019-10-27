using System.ComponentModel.DataAnnotations;

namespace PFCToolbox.Common.Model
{
    public partial class Location : DatabaseEntity
    {
        [Required]
        public string LocationName { get; set; }
    }
}
