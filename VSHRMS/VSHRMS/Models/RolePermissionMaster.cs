namespace VSHRMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RolePermissionMaster")]
    public partial class RolePermissionMaster
    {
        public long id { get; set; }

        public int RoleCode { get; set; }
        public int PageCode { get; set; }

        public bool Add { get; set; }

        public bool Edit { get; set; }

        public bool View { get; set; }

        public bool Delete { get; set; }

        public int? ConCode { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("RoleCode")]
        public RoleMaster RoleMaster { get; set; }
        [ForeignKey("PageCode")]
        public MapPages MapPages { get; set; }
    }
}
