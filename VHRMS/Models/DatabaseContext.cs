namespace VHRMS.Models
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

        public virtual DbSet<ConcernMaster> ConcernMasters { get; set; }
        public virtual DbSet<LicenseMaster> LicenseMasters { get; set; }
        public virtual DbSet<PageMaster> PageMasters { get; set; }
        public virtual DbSet<PermissionRole> PermissionRoles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
        }
    }
}
