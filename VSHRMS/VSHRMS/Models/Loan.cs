namespace VSHRMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Loan")]
    public partial class Loan
    {
        public long id { get; set; }

        public long? LoanNo { get; set; }

        public DateTime? LoanStartDate { get; set; }

        public DateTime? LoanEndDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LoanAmount { get; set; }

        public int? NoOfDues { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LoanDueAmount { get; set; }

        public int? LevelCode { get; set; }

        public long? EmpCode { get; set; }

        public int? ConCode { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual EmpDetails EmpDetails { get; set; }

        public virtual LevelMaster LevelMaster { get; set; }
    }
}
