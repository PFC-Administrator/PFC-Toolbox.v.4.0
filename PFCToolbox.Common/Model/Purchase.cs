using System;
using System.ComponentModel.DataAnnotations;

namespace PFCToolbox.Common.Model
{
    public partial class Purchase : DatabaseEntity
    {
        [Required]
        public string InvoiceNumber { get; set; }

        public DateTime PurchaseDate { get; set; }

        public decimal PurchaseAmount { get; set; }

        public bool PurchaseReconciled { get; set; }

        public int VendorID { get; set; }

        public int SubdepartmentID { get; set; }

        public int LocationID { get; set; }

        public string PurchaseMemo { get; set; }

        public Location Location { get; set; }

        public Subdepartment Subdepartment { get; set; }

        public Vendor Vendor { get; set; }
    }
}
