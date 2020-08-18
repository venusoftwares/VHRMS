namespace VHRMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserRole
    {
        
        [Key]
        public int id { get; set; }

        [StringLength(50)]
        public string Role { get; set; }

        public int? Status { get; set; }

        public int? CreatedDate { get; set; }
    }
}
