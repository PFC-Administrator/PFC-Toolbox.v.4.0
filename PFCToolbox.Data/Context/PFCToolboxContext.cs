using System.Data.Entity;
using PFCToolbox.Common.Model;

namespace PFCToolbox.Data.Context
{
    public partial class PFCToolboxContext : DbContext
    {
        public PFCToolboxContext()
            : base("name=ToolboxConnection")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Expiration> Expirations { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<ProductUpdate> ProductUpdates { get; set; }
        public virtual DbSet<ProductUpdateStatus> ProductUpdateStatuses { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<RequestType> RequestTypes { get; set; }
        public virtual DbSet<SMSSubdepartment> SMSSubdepartments { get; set; }
        public virtual DbSet<Subdepartment> Subdepartments { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<Writeoff> Writeoffs { get; set; }
        public virtual DbSet<LabelSize> LabelSizes { get; set; }
        public virtual DbSet<SignSize> SignSizes { get; set; }
        public virtual DbSet<SMSCategory> SMSCategories { get; set; }
        public virtual DbSet<SMSReport> SMSReports { get; set; }
        public virtual DbSet<SMSVendor> SMSVendors { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Expirations)
                .WithRequired(e => e.Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SMSSubdepartment>()
                .Property(e => e.F1022)
                .IsUnicode(false);

            modelBuilder.Entity<SMSCategory>()
                .Property(e => e.F1023)
                .IsUnicode(false);

            modelBuilder.Entity<SMSCategory>()
                .Property(e => e.F1943)
                .IsUnicode(false);

            modelBuilder.Entity<SMSCategory>()
                .Property(e => e.F1022)
                .IsUnicode(false);

            modelBuilder.Entity<SMSReport>()
                .Property(e => e.F1024)
                .IsUnicode(false);

            modelBuilder.Entity<SMSVendor>()
                .Property(e => e.F27)
                .IsUnicode(false);

            modelBuilder.Entity<SMSVendor>()
                .Property(e => e.F334)
                .IsUnicode(false);
        }
    }
}
