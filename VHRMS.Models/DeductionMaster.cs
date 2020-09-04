namespace VHRMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DeductionMaster")]
    public partial class DeductionMaster
    {
        public int id { get; set; }

        [StringLength(50)]
        public string Deduction { get; set; }

        public int? ConCode { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
