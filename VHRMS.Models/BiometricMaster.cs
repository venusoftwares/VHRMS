namespace VHRMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BiometricMaster")]
    public partial class BiometricMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BiometricMaster()
        {
            EbiometricLogs = new HashSet<EbiometricLogs>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string IPAddress { get; set; }

        public int? Port { get; set; }

        public bool? Status { get; set; }

        [StringLength(50)]
        public string MachineType { get; set; }

        public int? ConCode { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual ConcernMaster ConcernMaster { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EbiometricLogs> EbiometricLogs { get; set; }
    }
}
