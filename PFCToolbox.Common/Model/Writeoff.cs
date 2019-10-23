namespace PFCToolbox.Common.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Writeoff : Entity
    {
        public int WriteoffID { get; set; }

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

        public virtual Location Location { get; set; }

        public virtual Subdepartment Subdepartment { get; set; }
    }
}
