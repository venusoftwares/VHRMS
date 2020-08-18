namespace VHRMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ConcernMaster")]
    public partial class ConcernMaster
    {
        
        [Key]
        public int id { get; set; }

        [StringLength(50)]
        public string Concern { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifyDate { get; set; }

      
    }
}
