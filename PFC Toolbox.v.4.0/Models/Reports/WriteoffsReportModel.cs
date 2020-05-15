using System.ComponentModel.DataAnnotations;

namespace PFC_Toolbox.v._4._0.Models
{
    public class WriteoffsReportModel
    {
        [DisplayAttribute(Name = "Writeoff Code")]
        public string WriteoffCode { get; set; }

        [DisplayAttribute(Name = "Item Name")]
        public string ItemName { get; set; }

        [DisplayAttribute(Name = "Quantity")]
        public string Quantity { get; set; }

        [DisplayAttribute(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }

        [DisplayAttribute(Name = "Total Price")]
        public decimal TotalPrice { get; set; }

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