namespace PFCToolbox.Common.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SMSCategory : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int F17 { get; set; }

        [StringLength(30)]
        public string F1023 { get; set; }

        [StringLength(40)]
        public string F1943 { get; set; }

        [StringLength(30)]
        public string F1022 { get; set; }
    }
}
