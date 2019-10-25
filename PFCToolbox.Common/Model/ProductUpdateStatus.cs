namespace PFCToolbox.Common.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductUpdateStatuses")]
    public partial class ProductUpdateStatus : DatabaseEntity
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public ProductUpdateStatus()
        //{
        //    ProductUpdates = new HashSet<ProductUpdate>();
        //}

        //[Key]
        //public int ProductStatusID { get; set; }

        [Column("ProductUpdateStatus")]
        [StringLength(255)]
        public string ProductUpdateStatus1 { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<ProductUpdate> ProductUpdates { get; set; }
    }
}
