namespace VSHRMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShiftMaster")]
    public partial class ShiftMaster
    {
        public int id { get; set; }

        public int BatchCode { get; set; }

        public int ShiftCode { get; set; }

        public DateTime? InTime { get; set; }

        public int? InTimeGrace { get; set; }

        public DateTime? BeforeInTime { get; set; }

        public int? BeforeInTimeGrace { get; set; }

        public DateTime? Break1From { get; set; }

        public DateTime? Break1To { get; set; }

        public DateTime? LunchFrom { get; set; }

        public DateTime? LunchTo { get; set; }

        public DateTime? Break2From { get; set; }

        public DateTime? Break2To { get; set; }

        public DateTime? OutTime { get; set; }

        public int? OutTimeGrace { get; set; }

        public DateTime? AfterOutTime { get; set; }

        public int? AfterOutTimeGrace { get; set; }

        public int? Level { get; set; }

        public int? ConCode { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("BatchCode")]
        public  BatchMaster BatchMaster { get; set; }
 
    }
}
