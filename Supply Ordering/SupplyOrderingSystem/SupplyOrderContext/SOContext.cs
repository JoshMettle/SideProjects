using Microsoft.EntityFrameworkCore;
using SupplyOrderDomain;
using SupplyOrderDomain.Locations;
using System.Data.Entity;

namespace SupplyOrderData
{
    public class SOContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var config = modelBuilder.Entity<Person>();
            config.ToTable("Person");
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Location> Locations { get; set; }
        //public DbSet<WarehouseLocation> Warehouse { get; set; }
        //public DbSet<StoreLocation> Store { get; set; }
        //public DbSet<VendorLocation> VendorLocation { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=P137G001-LCR\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}