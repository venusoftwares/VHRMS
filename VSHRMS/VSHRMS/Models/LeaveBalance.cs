namespace VSHRMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LeaveBalance")]
    public partial class LeaveBalance
    {
        public long id { get; set; }

        public long? LeaveCode { get; set; }

        public int? CatCode { get; set; }

        public long? EmpCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NoOfLeaves { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EarnLeaves { get; set; }

        [Column("LeaveBalance", TypeName = "numeric")]
        public decimal? LeaveBalance1 { get; set; }

        public int? LevelCode { get; set; }

        public int? ConCode { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual CategoryMaster CategoryMaster { get; set; }

        public virtual EmpDetails EmpDetails { get; set; }

        public virtual LeaveSettings LeaveSettings { get; set; }

        public virtual LevelMaster LevelMaster { get; set; }
    }
}
