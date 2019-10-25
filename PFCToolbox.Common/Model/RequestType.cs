namespace PFCToolbox.Common.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RequestType : DatabaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RequestType()
        {
            ProductUpdates = new HashSet<ProductUpdate>();
        }

        public int RequestTypeID { get; set; }

        [StringLength(255)]
        public string RequestName { get; set; }

        [StringLength(255)]
        public string RequestDescription { get; set; }

        public bool? Promotion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductUpdate> ProductUpdates { get; set; }
    }
}
