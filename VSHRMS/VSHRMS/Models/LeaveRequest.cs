namespace VSHRMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LeaveRequest")]
    public partial class LeaveRequest
    {
        public long id { get; set; }

        public DateTime? AppliedDate { get; set; }

        public long? EmpCode { get; set; }

        public int? LeaveTypeCode { get; set; }

        public DateTime? LeaveFrom { get; set; }

        public DateTime? LeaveTo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LeaveDuration { get; set; }

        public string Filepath { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        public long? ApprovalEmpCode { get; set; }

        public string Remarks { get; set; }

        public int? ConCode { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual EmpDetails EmpDetails { get; set; }

        public virtual EmpDetails EmpDetails1 { get; set; }

        public virtual LeaveTypeMaster LeaveTypeMaster { get; set; }
    }
}
