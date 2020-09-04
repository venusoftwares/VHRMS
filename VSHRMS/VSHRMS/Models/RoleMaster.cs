namespace VSHRMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoleMaster")]
    public partial class RoleMaster
    {
      

        public int id { get; set; }

        public int DashCode { get; set; }

        [StringLength(50)]
        public string Role { get; set; }

        public int? ConCode { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
 

        [ForeignKey("DashCode")]
        public  DashboardMaster DashboardMaster { get; set; }
 
    }
}
