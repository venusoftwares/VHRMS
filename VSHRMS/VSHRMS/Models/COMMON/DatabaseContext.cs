namespace VSHRMS.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
        }

        public virtual DbSet<ConcernMaster> ConcernMaster { get; set; }
        public virtual DbSet<DashboardMaster> DashboardMaster { get; set; }
        public virtual DbSet<RoleMaster> RoleMaster { get; set; }
        public virtual DbSet<RolePermissionMaster> RolePermissionMaster { get; set; }
        public virtual DbSet<UserMaster> UserMaster { get; set; }
        public virtual DbSet<MapPages> MapPages { get; set; }
        public virtual DbSet<LicenseMaster> LicenseMaster { get; set; }

        public virtual DbSet<Advance> Advance { get; set; }
        public virtual DbSet<AdvancePayment> AdvancePayment { get; set; }
        public virtual DbSet<AllowanceMaster> AllowanceMaster { get; set; }
        public virtual DbSet<BankMaster> BankMaster { get; set; }
        public virtual DbSet<BatchMaster> BatchMaster { get; set; }
        public virtual DbSet<BiometricMaster> BiometricMaster { get; set; }
        public virtual DbSet<CategoryMaster> CategoryMaster { get; set; }
        public virtual DbSet<DeductionMaster> DeductionMaster { get; set; }
        public virtual DbSet<DepartmentMaster> DepartmentMaster { get; set; }
        public virtual DbSet<DesignationMaster> DesignationMaster { get; set; }
        public virtual DbSet<EbiometricLogs> EbiometricLogs { get; set; }
        public virtual DbSet<EmpDetails> EmpDetails { get; set; }
        public virtual DbSet<EmpService> EmpService { get; set; }
        public virtual DbSet<LeaveBalance> LeaveBalance { get; set; }
        public virtual DbSet<LeaveRequest> LeaveRequest { get; set; }
        public virtual DbSet<LeaveSettings> LeaveSettings { get; set; }
        public virtual DbSet<LeaveTypeMaster> LeaveTypeMaster { get; set; }
        public virtual DbSet<LevelMaster> LevelMaster { get; set; }
        public virtual DbSet<Loan> Loan { get; set; }
        public virtual DbSet<LoanPayment> LoanPayment { get; set; }
        public virtual DbSet<PaySalStatement> PaySalStatement { get; set; }
        public virtual DbSet<ShiftMaster> ShiftMaster { get; set; }
        public virtual DbSet<WagesMaster> WagesMaster { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }
    }
}
