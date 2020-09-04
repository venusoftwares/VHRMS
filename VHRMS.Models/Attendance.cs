namespace VHRMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Attendance")]
    public partial class Attendance
    {
        public long id { get; set; }

        public DateTime? AttDate { get; set; }

        public long? EmpCode { get; set; }

        public int? BatchCode { get; set; }

        public long? ShiftCode { get; set; }

        public int? CatCode { get; set; }

        public int? DeptCode { get; set; }

        public int? DesigCode { get; set; }

        public int? LevelCode { get; set; }

        public DateTime? InTime { get; set; }

        public DateTime? Break1From { get; set; }

        public DateTime? Break1To { get; set; }

        public DateTime? LunchFrom { get; set; }

        public DateTime? LunchTo { get; set; }

        public DateTime? Break2From { get; set; }

        public DateTime? Break2To { get; set; }

        public DateTime? OutTime { get; set; }

        public DateTime? OTInTime { get; set; }

        public DateTime? OTBreakFrom { get; set; }

        public DateTime? OTBreakTo { get; set; }

        public DateTime? OTOutTime { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Present { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? OT { get; set; }

        [StringLength(50)]
        public string WeeklyOff { get; set; }

        [StringLength(50)]
        public string LeaveType { get; set; }

        public int? CLDays { get; set; }

        public int? ConCode { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual BatchMaster BatchMaster { get; set; }

        public virtual CategoryMaster CategoryMaster { get; set; }

        public virtual ConcernMaster ConcernMaster { get; set; }

        public virtual DepartmentMaster DepartmentMaster { get; set; }

        public virtual DesignationMaster DesignationMaster { get; set; }

        public virtual EmpDetails EmpDetails { get; set; }

        public virtual LevelMaster LevelMaster { get; set; }
    }
}
