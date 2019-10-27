using System;
using System.ComponentModel.DataAnnotations;

namespace PFCToolbox.Common.Model
{
    public partial class Expiration : DatabaseEntity
    {
        public string ExpirationCode { get; set; }

        [Required]
        public string ExpirationDescription { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int LocationID { get; set; }

        public string ExpirationMemo { get; set; }

        public Location Location { get; set; }
    }
}
