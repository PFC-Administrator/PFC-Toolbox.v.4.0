using System.ComponentModel.DataAnnotations;

namespace PFC_Toolbox.v._4._0.Models
{
    public class PurchasesReportModel
    {
        [DisplayAttribute(Name = "Purchase ID")]
        public string PurchaseID { get; set; }

        [DisplayAttribute(Name = "Invoice Number")]
        public string InvoiceNumber { get; set; }

        [DisplayAttribute(Name = "Vendor ID")]
        public string VendorID { get; set; }

        [DisplayAttribute(Name = "Purchase Date")]
        public string PurchaseDate { get; set; }

        [DisplayAttribute(Name = "Purchase Amount")]
        public decimal PurchaseAmount { get; set; }

        [DisplayAttribute(Name = "Purchase Reconciled")]
        public string PurchaseReconciled { get; set; }

        [DisplayAttribute(Name = "Subdepartment")]
        public string SubdepartmentID { get; set; }

        [DisplayAttribute(Name = "Location")]
        public string LocationID { get; set; }

        [DisplayAttribute(Name = "Memo")]
        public string PurchaseMemo { get; set; }

        [DisplayAttribute(Name = "Created By")]
        public string CreatedBy { get; set; }

        [DisplayAttribute(Name = "Date Created")]
        public string DateCreated { get; set; }
    }
}