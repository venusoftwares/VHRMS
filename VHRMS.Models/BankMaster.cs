namespace VHRMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BankMaster")]
    public partial class BankMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BankMaster()
        {
            EmpDetails = new HashSet<EmpDetails>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string BankName { get; set; }

        public int? ConCode { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual ConcernMaster ConcernMaster { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmpDetails> EmpDetails { get; set; }
    }
}
