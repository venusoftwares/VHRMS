namespace VHRMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PermissionRole")]
    public partial class PermissionRole
    {
        
        [Key]
        public int id { get; set; }

        public int PageId { get; set; }

        public int RoleId { get; set; }

        public bool Add { get; set; }

        public bool Edit { get; set; }

        public bool View { get; set; }

        public bool Delete { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public int ConCode { get; set; }


        [ForeignKey("PageId")]
        public PageMaster PageMaster { get; set; }
        [ForeignKey("RoleId")]
        public UserRole UserRole { get; set; }
    }
}
