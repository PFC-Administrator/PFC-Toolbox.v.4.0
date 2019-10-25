namespace PFCToolbox.Common.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SMSVendor : DatabaseEntity
    {
        [Key]
        [StringLength(14)]
        public string F27 { get; set; }

        [StringLength(40)]
        public string F334 { get; set; }
    }
}
