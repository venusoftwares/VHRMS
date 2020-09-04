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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }
    }
}
