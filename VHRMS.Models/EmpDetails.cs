namespace VHRMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EmpDetails
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmpDetails()
        {
            Advance = new HashSet<Advance>();
            AdvancePayment = new HashSet<AdvancePayment>();
            Attendance = new HashSet<Attendance>();
            LeaveBalance = new HashSet<LeaveBalance>();
            LeaveRequest = new HashSet<LeaveRequest>();
            LeaveRequest1 = new HashSet<LeaveRequest>();
            Loan = new HashSet<Loan>();
            LoanPayment = new HashSet<LoanPayment>();
            PaySalStatement = new HashSet<PaySalStatement>();
            WagesMaster = new HashSet<WagesMaster>();
        }

        public long id { get; set; }

        [StringLength(50)]
        public string EmployeeName { get; set; }

        [StringLength(50)]
        public string TicketNo { get; set; }

        [StringLength(50)]
        public string Mcid { get; set; }

        [StringLength(50)]
        public string CardNo { get; set; }

        [StringLength(50)]
        public string MobileNo { get; set; }

        [StringLength(50)]
        public string AadharCard { get; set; }

        public DateTime? DOB { get; set; }

        public DateTime? DOJ { get; set; }

        public DateTime? DOR { get; set; }

        public int? Status { get; set; }

        [StringLength(50)]
        public string WeeklyOff { get; set; }

        [StringLength(50)]
        public string FatherName { get; set; }

        [StringLength(50)]
        public string MotherName { get; set; }

        [StringLength(50)]
        public string PaymentMode { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public int? BankCode { get; set; }

        [StringLength(50)]
        public string AccountNo { get; set; }

        [StringLength(50)]
        public string IFSCCode { get; set; }

        public int? ConCode { get; set; }

        public int? CatCode { get; set; }

        public int? DeptCode { get; set; }

        public int? DesigCode { get; set; }

        public int? BatchCode { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Advance> Advance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdvancePayment> AdvancePayment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attendance> Attendance { get; set; }

        public virtual BankMaster BankMaster { get; set; }

        public virtual BatchMaster BatchMaster { get; set; }

        public virtual CategoryMaster CategoryMaster { get; set; }

        public virtual ConcernMaster ConcernMaster { get; set; }

        public virtual DepartmentMaster DepartmentMaster { get; set; }

        public virtual DesignationMaster DesignationMaster { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LeaveBalance> LeaveBalance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LeaveRequest> LeaveRequest { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LeaveRequest> LeaveRequest1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Loan> Loan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoanPayment> LoanPayment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaySalStatement> PaySalStatement { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WagesMaster> WagesMaster { get; set; }
    }
}
