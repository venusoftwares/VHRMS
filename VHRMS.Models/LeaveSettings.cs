namespace VHRMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LeaveSettings
    {
    

        public long id { get; set; }

        public int? CatCode { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int LeaveTypeCode { get; set; }

        public int? Month { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NoOfLeaves { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PerMonthOfLeaves { get; set; }

        public int? LevelCode { get; set; }

        public int? ConCode { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("CatCode")]
        public  CategoryMaster CategoryMaster { get; set; }
        [ForeignKey("LeaveTypeCode")]
        public  LeaveTypeMaster LeaveTypeMaster { get; set; }
        [ForeignKey("LevelCode")]
        public  LevelMaster LevelMaster { get; set; }
    }
}
