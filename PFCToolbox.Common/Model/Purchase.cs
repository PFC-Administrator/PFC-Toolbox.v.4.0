namespace PFCToolbox.Common.Model
{
    using PFCToolbox.Common.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Purchase : DatabaseEntity
    {
        public int PurchaseID { get; set; }

        [Required]
        public string InvoiceNumber { get; set; }

        public DateTime PurchaseDate { get; set; }

        public decimal PurchaseAmount { get; set; }

        public bool PurchaseReconciled { get; set; }

        public int VendorID { get; set; }

        public int SubdepartmentID { get; set; }

        public int LocationID { get; set; }

        public string PurchaseMemo { get; set; }

        public virtual Location Location { get; set; }

        public virtual Subdepartment Subdepartment { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
