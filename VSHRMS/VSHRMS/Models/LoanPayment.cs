namespace VSHRMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoanPayment")]
    public partial class LoanPayment
    {
        public long id { get; set; }

        public DateTime? LoanPaymentDate { get; set; }

        public long? LoanNo { get; set; }

        [StringLength(50)]
        public string PaymentType { get; set; }

        public int? LevelCode { get; set; }

        public long? EmpCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PaymentAmount { get; set; }

        public int? ConCode { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual EmpDetails EmpDetails { get; set; }

        public virtual LevelMaster LevelMaster { get; set; }
    }
}
