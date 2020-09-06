namespace VSHRMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WagesMaster")]
    public partial class WagesMaster
    {
        public long id { get; set; }

        public long? EmpCode { get; set; }

        public int? LevelCode { get; set; }

        public DateTime? EffectDate { get; set; }

        [StringLength(50)]
        public string WagesType { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Basic { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Da { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? HRA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Academic { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Medical { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Education { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Mobile { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Petrol { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Tea { get; set; }

        public int? ConCode { get; set; }

        public int? CatCode { get; set; }

        public int? DeptCode { get; set; }

        public int? DesigCode { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual CategoryMaster CategoryMaster { get; set; }

        public virtual DepartmentMaster DepartmentMaster { get; set; }

        public virtual DesignationMaster DesignationMaster { get; set; }

        public virtual EmpDetails EmpDetails { get; set; }

        public virtual LevelMaster LevelMaster { get; set; }
    }
}
