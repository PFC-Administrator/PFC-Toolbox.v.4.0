using System;
using System.ComponentModel.DataAnnotations;

namespace PFC_Toolbox.v._4._0.Models
{
    public class ItemSingleTotalbySubdepartmentbyPeriodModel
    {
        [DisplayAttribute(Name = "UPC/PLU")]
        public string ItemCode { get; set; }

        [DisplayAttribute(Name = "Subdepartment")]
        public string Subdept { get; set; }

        [DisplayAttribute(Name = "Brand")]
        public string ItemBrand { get; set; }

        [DisplayAttribute(Name = "Description")]
        public string ItemDescription { get; set; }

        [DisplayAttribute(Name = "Size")]
        public string ItemSize { get; set; }

        [DisplayAttribute(Name = "Weight")]
        public double SalesWeight { get; set; }

        [DisplayAttribute(Name = "Total Sales")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal SalesTotal { get; set; }

        [DisplayAttribute(Name = "Quantity")]
        [DisplayFormat(DataFormatString = "{0}")]
        public double SalesQuantity { get; set; }

        [DisplayAttribute(Name = "Weight2")]
        public double SalesWeight2 { get; set; }

        [DisplayAttribute(Name = "Total Sales2")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal SalesTotal2 { get; set; }

        [DisplayAttribute(Name = "Quantity2")]
        [DisplayFormat(DataFormatString = "{0}")]
        public double SalesQuantity2 { get; set; }

        [DisplayAttribute(Name = "Weight3")]
        public double SalesWeight3 { get; set; }

        [DisplayAttribute(Name = "Total Sales3")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal SalesTotal3 { get; set; }

        [DisplayAttribute(Name = "Quantity3")]
        [DisplayFormat(DataFormatString = "{0}")]
        public double SalesQuantity3 { get; set; }

        [DisplayAttribute(Name = "Trend")]
        [DisplayFormat(DataFormatString = "{0:P}")]
        public Decimal SalesTrend { get; set; }
    }
}