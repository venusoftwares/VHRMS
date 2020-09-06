namespace VSHRMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LeaveSettings
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LeaveSettings()
        {
            LeaveBalance = new HashSet<LeaveBalance>();
        }

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

        public virtual CategoryMaster CategoryMaster { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LeaveBalance> LeaveBalance { get; set; }

        public virtual LeaveTypeMaster LeaveTypeMaster { get; set; }

        public virtual LevelMaster LevelMaster { get; set; }
    }
}
