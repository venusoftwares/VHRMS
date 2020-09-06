namespace VSHRMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Advance")]
    public partial class Advance
    {
        public long id { get; set; }

        public DateTime? AdvanceDate { get; set; }

        public long? AdvNo { get; set; }

        public int? LevelCode { get; set; }

        public long? EmpCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Amount { get; set; }

        public int? ConCode { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual EmpDetails EmpDetails { get; set; }

        public virtual LevelMaster LevelMaster { get; set; }
    }
}
