using System;
using System.ComponentModel.DataAnnotations;

namespace PFC_Toolbox.v._4._0.Models
{
    public class WriteoffsSummaryModel
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
    }
}