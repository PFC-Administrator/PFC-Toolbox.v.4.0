using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PFCToolbox.Common.Model
{
    public partial class Subdepartment : DatabaseEntity
    {
        [Required]
        public string SubdepartmentName { get; set; }

        public ICollection<Purchase> Purchases { get; set; }

        public ICollection<Writeoff> Writeoffs { get; set; }
    }
}
