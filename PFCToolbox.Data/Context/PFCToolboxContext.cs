using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using PFCToolbox.Common.Model;

namespace PFCToolbox.Data.Context
{
    public class PFCToolboxContext : DbContext
    {
        public PFCToolboxContext() // default constructer
            : this(ConfigurationManager.ConnectionStrings["ToolboxConnection"].ConnectionString)
        {

        }

        protected PFCToolboxContext(string connectionString) // override constructor
            : base(connectionString)
        {

        }

        public DbSet<Expiration> Expirations { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ProductUpdate> ProductUpdates { get; set; }
        public DbSet<ProductUpdateStatus> ProductUpdateStatuses { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<RequestType> RequestTypes { get; set; }
        public DbSet<SMSSubdepartment> SMSSubdepartments { get; set; }
        public DbSet<Subdepartment> Subdepartments { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Writeoff> Writeoffs { get; set; }
        public DbSet<LabelSize> LabelSizes { get; set; }
        public DbSet<SignSize> SignSizes { get; set; }
        public DbSet<SMSCategory> SMSCategories { get; set; }
        public DbSet<SMSReport> SMSReports { get; set; }
        public DbSet<SMSVendor> SMSVendors { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LabelSize>()
                .Property(e => e.ID)
                .HasColumnName("LabelID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Expirations)
                .WithRequired(e => e.Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductUpdateStatus>()
                .Property(e => e.ID)
                .HasColumnName("ProductStatusID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<SignSize>()
                .Property(e => e.ID)
                .HasColumnName("SignID");

            modelBuilder.Entity<SMSSubdepartment>()
                .Property(e => e.ID)
                .HasColumnName("F04")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<SMSSubdepartment>()
                .Property(e => e.F1022)
                .IsUnicode(false);

            modelBuilder.Entity<SMSCategory>()
                .Property(e => e.ID)
                .HasColumnName("F17")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

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
                .Property(e => e.ID)
                .HasColumnName("F18")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<SMSReport>()
                .Property(e => e.F1024)
                .IsUnicode(false);

            modelBuilder.Entity<SMSVendor>()
                .Property(e => e.ID)
                .HasColumnName("F27")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsUnicode(false);

            modelBuilder.Entity<SMSVendor>()
                .Property(e => e.F334)
                .IsUnicode(false);

            modelBuilder.Entity<Subdepartment>()
                .Property(e => e.ID)
                .HasColumnName("SubdepartmentID");
        }
    }
}
