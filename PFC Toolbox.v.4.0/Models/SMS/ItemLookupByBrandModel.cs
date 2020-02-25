using System;
using System.ComponentModel.DataAnnotations;

namespace PFC_Toolbox.v._4._0.Models
{
    public class ItemLookupByBrandModel
    {
        [DisplayAttribute(Name = "Item Code")]
        public string ItemCode { get; set; }

        [DisplayAttribute(Name = "Brand")]
        public string ItemBrand { get; set; }

        [DisplayAttribute(Name = "Description")]
        public string ItemDescription { get; set; }

        [DisplayAttribute(Name = "Long Description")]
        public string ItemLongDesc { get; set; }

        [DisplayAttribute(Name = "Item Size")]
        public string ItemSize { get; set; }

        [DisplayAttribute(Name = "Category")]
        public string ItemCategory { get; set; }

        [DisplayAttribute(Name = "Report")]
        public string ItemReport { get; set; }

        [DisplayAttribute(Name = "Subdepartment")]
        public string ItemSubdepartment { get; set; }

        [DisplayAttribute(Name = "Weighed Item")]
        public string ItemScaled { get; set; }

        [DisplayAttribute(Name = "Taxable")]
        public string ItemTaxed { get; set; }

        [DisplayAttribute(Name = "Food Stamp")]
        public string ItemFoodStamp { get; set; }

        [DisplayAttribute(Name = "Regular Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ItemRegPrice { get; set; }

        [DisplayAttribute(Name = "TPR Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ItemTPR { get; set; }

        [DisplayAttribute(Name = "TPR Start")]
        public string ItemStartTPR { get; set; }

        [DisplayAttribute(Name = "TPR End")]
        public string ItemEndTPR { get; set; }

        [DisplayAttribute(Name = "TPR Package")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ItemPkgTPR { get; set; }

        [DisplayAttribute(Name = "Regular Package")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ItemPkgPrice { get; set; }

        [DisplayAttribute(Name = "Active Vendor")]
        public string ItemVendor { get; set; }

        [DisplayAttribute(Name = "Vendor Code")]
        public string ItemVendorCode { get; set; }

        [DisplayAttribute(Name = "Current Cost")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ItemCost { get; set; }

        [DisplayAttribute(Name = "Current Margin")]
        [DisplayFormat(DataFormatString = "{0:#\\%}")]
        public decimal ItemMargin { get; set; }
    }
}