using System;
using System.ComponentModel.DataAnnotations;

namespace PFC_Toolbox.v._4._0.Models
{
    public class StoreMultiTotalsModel
    {
        [DisplayAttribute(Name = "Weight")]
        [DisplayFormat(DataFormatString = "{0:0.000}")]
        public double SalesWeight { get; set; }

        [DisplayAttribute(Name = "Total Sales")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal SalesTotal { get; set; }

        [DisplayAttribute(Name = "Quantity")]
        [DisplayFormat(DataFormatString = "{0:0.000}")]
        public double SalesQuantity { get; set; }

        [DisplayAttribute(Name = "Transactions")]
        public Int32 SalesTransactions { get; set; }
    }
}