namespace VHRMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PaySalStatement")]
    public partial class PaySalStatement
    {
        public long id { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalWorkingDays { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalAbsentDays { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalLeaveDays { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? BasicSalary { get; set; }

        [StringLength(10)]
        public string Da { get; set; }

        [StringLength(10)]
        public string Allowance { get; set; }

        [StringLength(10)]
        public string Deduction { get; set; }

        [StringLength(10)]
        public string Esi { get; set; }

        [StringLength(10)]
        public string Pf { get; set; }

        [StringLength(10)]
        public string OtherDeduction { get; set; }

        [StringLength(10)]
        public string GrossSalary { get; set; }

        [StringLength(10)]
        public string NetSalary { get; set; }

        public int? ConCode { get; set; }

        public int? CatCode { get; set; }

        public int? DeptCode { get; set; }

        public int? DesigCode { get; set; }

        public int? BatchCode { get; set; }

        public long? EmpCode { get; set; }

        public int? LevelCode { get; set; }

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
