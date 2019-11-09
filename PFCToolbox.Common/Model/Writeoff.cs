using System;
using System.ComponentModel.DataAnnotations;

namespace PFCToolbox.Common.Model
{
    public partial class Writeoff : DatabaseEntity
    {
        public string WriteoffCode { get; set; }

        [Required]
        public string WriteoffItemName { get; set; }

        public decimal WriteoffQuantity { get; set; }

        public decimal WriteoffUnitPrice { get; set; }

        public decimal WriteoffTotalPrice { get; set; }

        [Required]
        public string WriteoffUserName { get; set; }

        public DateTime WriteoffDateTime { get; set; }

        public int LocationID { get; set; }

        public int SubdepartmentID { get; set; }

        public string WriteoffMemo { get; set; }

        public Location Location { get; set; }

        public Subdepartment Subdepartment { get; set; }
    }
}
