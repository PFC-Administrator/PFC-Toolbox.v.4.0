using System;
using System.ComponentModel.DataAnnotations;

namespace PFC_Toolbox.v._4._0.Models
{
    public class ItemSingleTotalModel
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

        [DisplayAttribute(Name = "Quantity")]
        public double SalesQuantity { get; set; }

        [DisplayAttribute(Name = "Amount")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal SalesAmount { get; set; }

        [DisplayAttribute(Name = "Units")]
        [DisplayFormat(DataFormatString = "{0}")]
        public double SalesUnits { get; set; }
    }
}