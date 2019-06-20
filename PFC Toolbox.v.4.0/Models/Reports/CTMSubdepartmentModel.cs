using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DataTables;

namespace PFC_Toolbox.v._4._0.Models
{
    public class CTMSubdepartmentModel
    {
        [DisplayAttribute(Name = "UPC/PLU")]
        public string ItemCode { get; set; }

        [DisplayAttribute(Name = "Brand")]
        public string ItemBrand { get; set; }

        [DisplayAttribute(Name = "Description")]
        public string ItemDescription { get; set; }

        [DisplayAttribute(Name = "Weight")]
        public double SalesWeight { get; set; }

        [DisplayAttribute(Name = "Quantity")]
        [DisplayFormat(DataFormatString = "{0}")]
        public double SalesQuantity { get; set; }

        [DisplayAttribute(Name = "Total Sales")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal SalesAmount { get; set; }

        [DisplayAttribute(Name = "Retail")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal SalesRetail { get; set; }

        [DisplayAttribute(Name = "Cost")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal SalesCost { get; set; }

        [DisplayAttribute(Name = "Vendor ID")]
        public String SalesVendorID { get; set; }

        [DisplayAttribute(Name = "Reorder Code")]
        public String SalesReorder { get; set; }

        [DisplayAttribute(Name = "% of Sales")]
        [DisplayFormat(DataFormatString = "{0:P}")]
        public Decimal SalesPercent { get; set; }

        [DisplayAttribute(Name = "Applied Margin")]
        [DisplayFormat(DataFormatString = "{0:P}")]
        public Decimal SalesAppliedMargin { get; set; }

        [DisplayAttribute(Name = "CTM")]
        [DisplayFormat(DataFormatString = "{0:P}")]
        public Decimal SalesCTM { get; set; }
    }
}