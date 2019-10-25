namespace PFCToolbox.Common.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LabelSize : DatabaseEntity
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int LabelID { get; set; }

        [StringLength(255)]
        public string LabelSizes { get; set; }
    }
}
