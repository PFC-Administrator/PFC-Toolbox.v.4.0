using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DataTables;

namespace PFC_Toolbox.v._4._0.Models
{
    public class ItemSingleTotalbySubdepartmentModel
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