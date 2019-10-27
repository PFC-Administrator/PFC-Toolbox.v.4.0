using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFCToolbox.Common.Model
{
    public partial class ProductUpdate : DatabaseEntity
    {
        public bool? UpdatedInSMS { get; set; }
        public bool? UpdatedinMettler { get; set; }
        [StringLength(3)]
        public string DeptManager { get; set; }
        [StringLength(255)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? DateCreated { get; set; }
        [StringLength(255)]
        public string ReviewedBy { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? ReviewedDate { get; set; }
        [StringLength(2)]
        public string SMSUserState { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? DateExported { get; set; }
        [StringLength(255)]
        public string Exportedby { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? LastUpdatedOn { get; set; }
        [StringLength(255)]
        public string LastUpdatedBy { get; set; }
        [StringLength(255)]
        public string CompletedBy { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? CompletedDate { get; set; }
        public int? PromoID { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? PromoTPRStartDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? PromoTPREndDate { get; set; }
        public double? PromoTPRPrice { get; set; }
        [StringLength(255)]
        public string F01 { get; set; }
        [StringLength(50)]
        public string OBJ_TAB_F155 { get; set; }
        [StringLength(255)]
        public string OBJ_TAB_F29 { get; set; }
        [StringLength(255)]
        public string OBJ_TAB_F22 { get; set; }
        [StringLength(255)]
        public string OBJ_TAB_F255 { get; set; }
        public int? OBJ_TAB_F16 { get; set; }
        public int? OBJ_TAB_F17 { get; set; }
        public int? OBJ_TAB_F18 { get; set; }
        [StringLength(255)]
        public string POS_TAB_F02 { get; set; }
        public int? POS_TAB_F04 { get; set; }
        public bool? POS_TAB_F79 { get; set; }
        public bool? POS_TAB_F80 { get; set; }
        public bool? POS_TAB_F81 { get; set; }
        public bool? POS_TAB_F150 { get; set; }
        public int? POS_TAB_F171 { get; set; }
        public int? LIKE_TAB_F122 { get; set; }
        public double? PRICE_TAB_F30 { get; set; }
        public int? PRICE_TAB_F49 { get; set; }
        [StringLength(255)]
        public string COST_TAB_F27 { get; set; }
        [StringLength(50)]
        public string COST_TAB_F26 { get; set; }
        public int? COST_TAB_F19 { get; set; }
        public double? COST_TAB_F38 { get; set; }
        public int? LabelID { get; set; }
        [StringLength(255)]
        public string LabelSizes { get; set; }
        [Column("LABEL QTY")]
        [StringLength(255)]
        public string LABEL_QTY { get; set; }
        public int? SignID { get; set; }
        [StringLength(255)]
        public string SignSizes { get; set; }
        [Column("SIGN QTY")]
        [StringLength(255)]
        public string SIGN_QTY { get; set; }
        [StringLength(255)]
        public string IsaPLURequired { get; set; }
        public double? TareNetWeight { get; set; }
        public int? ShelfLife { get; set; }
        [StringLength(255)]
        public string COOLInformation { get; set; }
        public int? ScaleDepartment { get; set; }
        public int? ScalePLU { get; set; }
        public int? ScaleUPC { get; set; }
        [StringLength(255)]
        public string IsMettlerRequired { get; set; }
        public int? ScaleStoreID { get; set; }
        public int? ScaleItemTypeID { get; set; }
        public int? ScaleDeptOpposite { get; set; }
        public bool? POS_TAB_F83 { get; set; }
        [Column(TypeName = "ntext")]
        public string IngredientList { get; set; }
        [Column(TypeName = "ntext")]
        public string AdditionalRequestNotes { get; set; }

        public int? RequestTypeID { get; set; }
        public RequestType RequestType { get; set; }

        public int? LocationID { get; set; }
        public Location Location { get; set; }

        public int? ProductUpdateStatusID { get; set; }
        public ProductUpdateStatus ProductUpdateStatus { get; set; }

        [StringLength(255)]
        public string ProductUpdateStatusDescription { get; set; }
    }
}
