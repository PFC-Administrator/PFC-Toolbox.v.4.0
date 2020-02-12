using System;
using System.ComponentModel.DataAnnotations;

namespace PFC_Toolbox.v._4._0.Models
{
    public class PurchasesSummaryModel
    {
        [DisplayAttribute(Name = "Subdepartment")]
        public string Subdept { get; set; }

        [DisplayAttribute(Name = "Location")]
        public string Location { get; set; }

        [DisplayAttribute(Name = "WeekStart")]
        public string WeekStart { get; set; }

        [DisplayAttribute(Name = "TotalAmount")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal SalesTotal { get; set; }

        [DisplayAttribute(Name = "ReconciledAmount")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal SalesReconciled { get; set; }

        [DisplayAttribute(Name = "AmountDifferent")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal SalesDifferent { get; set; }
    }
}