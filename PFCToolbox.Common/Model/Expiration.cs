namespace PFCToolbox.Common.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Expiration : Entity
    {
        public int ExpirationID { get; set; }

        public string ExpirationCode { get; set; }

        [Required]
        public string ExpirationDescription { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int LocationID { get; set; }

        public string ExpirationMemo { get; set; }

        public virtual Location Location { get; set; }
    }
}
