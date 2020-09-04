namespace VHRMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmpService")]
    public partial class EmpService
    {
        public long id { get; set; }

        public long? EmpCode { get; set; }

        public int? LevelCode { get; set; }

        public DateTime? EffectDate { get; set; }

        [StringLength(50)]
        public string Remarks { get; set; }

        public int? ConCode { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual ConcernMaster ConcernMaster { get; set; }

        public virtual LevelMaster LevelMaster { get; set; }
    }
}
