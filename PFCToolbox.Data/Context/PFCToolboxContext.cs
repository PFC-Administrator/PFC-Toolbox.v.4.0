using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using PFCToolbox.Common.Model;

namespace PFCToolbox.Data.Context
{
    public interface IPFCToolboxContext : IDisposable
    {
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
    }

    public class PFCToolboxContext : DbContext, IPFCToolboxContext
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
        public DbSet<LabelSize> LabelSizes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ProductUpdate> ProductUpdates { get; set; }
        public DbSet<ProductUpdateStatus> ProductUpdateStatuses { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<RequestType> RequestTypes { get; set; }
        public DbSet<SignSize> SignSizes { get; set; }
        public DbSet<SMSCategory> SMSCategories { get; set; }
        public DbSet<SMSReport> SMSReports { get; set; }
        public DbSet<SMSSubdepartment> SMSSubdepartments { get; set; }
        public DbSet<SMSVendor> SMSVendors { get; set; }
        public DbSet<Subdepartment> Subdepartments { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Writeoff> Writeoffs { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Expiration mappings

            modelBuilder.Entity<Expiration>()
                .HasRequired(e => e.Location);

            modelBuilder.Entity<Expiration>()
                .Property(e => e.ID)
                .HasColumnName("ExpirationID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // LabelSize mappings

            modelBuilder.Entity<LabelSize>()
                .Property(e => e.ID)
                .HasColumnName("LabelID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Location mappings

            modelBuilder.Entity<Location>()
                .Property(e => e.ID)
                .HasColumnName("LocationID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // ProductUpdate mappings

            modelBuilder.Entity<ProductUpdate>()
                .Property(e => e.ID)
                .HasColumnName("ProductUpdateID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<ProductUpdate>()
                .Property(e => e.ProductUpdateStatusDescription)
                .HasColumnName("ProductUpdateStatus");

            modelBuilder.Entity<ProductUpdate>()
                .Property(e => e.ProductUpdateStatusID)
                .HasColumnName("ProductStatusID");

            // ProductUpdateStatus mappings

            modelBuilder.Entity<ProductUpdateStatus>()
                .ToTable("ProductUpdateStatuses");

            modelBuilder.Entity<ProductUpdateStatus>()
                .Property(e => e.ID)
                .HasColumnName("ProductStatusID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<ProductUpdateStatus>()
                .Property(e => e.ProductUpdateStatusDescription)
                .HasColumnName("ProductUpdateStatus");

            // Purchase mappings

            modelBuilder.Entity<Purchase>()
                .Property(e => e.ID)
                .HasColumnName("PurchaseID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // RequestType mappings

            modelBuilder.Entity<RequestType>()
                .Property(e => e.ID)
                .HasColumnName("RequestTypeID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // SignSize mappings

            modelBuilder.Entity<SignSize>()
                .Property(e => e.ID)
                .HasColumnName("SignID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // SMSSubdepartment mappings

            modelBuilder.Entity<SMSSubdepartment>()
                .Property(e => e.ID)
                .HasColumnName("F04")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<SMSSubdepartment>()
                .Property(e => e.F1022)
                .IsUnicode(false);

            // SMSCategory mappings

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

            // SMSReport mappings

            modelBuilder.Entity<SMSReport>()
                .Property(e => e.ID)
                .HasColumnName("F18")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<SMSReport>()
                .Property(e => e.F1024)
                .IsUnicode(false);

            // SMSVendor mappings

            modelBuilder.Entity<SMSVendor>()
                .Property(e => e.ID)
                .HasColumnName("F27")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsUnicode(false);

            modelBuilder.Entity<SMSVendor>()
                .Property(e => e.F334)
                .IsUnicode(false);

            // Subdepartment mappings

            modelBuilder.Entity<Subdepartment>()
                .Property(e => e.ID)
                .HasColumnName("SubdepartmentID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Vendor mappings

            modelBuilder.Entity<Vendor>()
                .Property(e => e.ID)
                .HasColumnName("VendorID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Writeoff mappings

            modelBuilder.Entity<Writeoff>()
                .Property(e => e.ID)
                .HasColumnName("WriteoffID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
