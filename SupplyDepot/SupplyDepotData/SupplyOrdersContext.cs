using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SupplyDepotDomain;

namespace SupplyDepotData;

public partial class SupplyOrdersContext : DbContext
{
    public SupplyOrdersContext()
    {
    }

    public SupplyOrdersContext(DbContextOptions<SupplyOrdersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderHeader> OrderHeaders { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAccessLevel> UserAccessLevels { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    public virtual DbSet<VendorOrderDetail> VendorOrderDetails { get; set; }

    public virtual DbSet<VendorOrderHeader> VendorOrderHeaders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=P137G001-LCR\\SQLEXPRESS;Initial Catalog=SupplyOrders;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK_location");

            entity.ToTable("Location");

            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.Address1)
                .HasMaxLength(250)
                .HasColumnName("address1");
            entity.Property(e => e.Address2)
                .HasMaxLength(250)
                .HasColumnName("address2");
            entity.Property(e => e.City)
                .HasMaxLength(200)
                .HasColumnName("city");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("state");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(10)
                .HasColumnName("zip_code");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK_Order_Detail_1");

            entity.ToTable("Order_Detail");

            entity.Property(e => e.OrderDetailId).HasColumnName("order_detail_id");
            entity.Property(e => e.Amount)
                .HasColumnType("money")
                .HasColumnName("amount");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_order_detail_order_id");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_order_detail_product");
        });

        modelBuilder.Entity<OrderHeader>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK_order_header");

            entity.ToTable("Order_Header");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("order_date");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("money")
                .HasColumnName("total_amount");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.OrderHeaders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_order_header_user");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK_person");

            entity.ToTable("Person");

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK_product_id");

            entity.ToTable("Product");

            entity.HasIndex(e => new { e.VendorId, e.VendorProductNumber }, "UQ_vendor_product").IsUnique();

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.CaseQty).HasColumnName("case_qty");
            entity.Property(e => e.MaximumQty).HasColumnName("maximum_qty");
            entity.Property(e => e.MinimumQty).HasColumnName("minimum_qty");
            entity.Property(e => e.PricePerCase)
                .HasColumnType("money")
                .HasColumnName("price_per_case");
            entity.Property(e => e.ProductDescription)
                .HasMaxLength(400)
                .HasColumnName("product_description");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductType).HasColumnName("product_type");
            entity.Property(e => e.VendorId).HasColumnName("vendor_id");
            entity.Property(e => e.VendorProductNumber)
                .HasMaxLength(50)
                .HasColumnName("vendor_product_number");

            entity.HasOne(d => d.ProductTypeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductType)
                .HasConstraintName("FK_product_category");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Products)
                .HasForeignKey(d => d.VendorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vendor_id");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK_product_category");

            entity.ToTable("Product_Category");

            entity.HasIndex(e => e.CategoryName, "UK_product_category_name").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(200)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_user");

            entity.ToTable("User");

            entity.HasIndex(e => e.Username, "UQ_username").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.AccessLevel)
                .HasDefaultValueSql("((1))")
                .HasColumnName("access_level");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.Salt)
                .HasMaxLength(50)
                .HasColumnName("salt");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.AccessLevelNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.AccessLevel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_access_level");

            entity.HasOne(d => d.Person).WithMany(p => p.Users)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_person_id");
        });

        modelBuilder.Entity<UserAccessLevel>(entity =>
        {
            entity.HasKey(e => e.AccessLevelId).HasName("PK_access_level");

            entity.ToTable("User_Access_Level");

            entity.Property(e => e.AccessLevelId).HasColumnName("access_level_id");
            entity.Property(e => e.AccessLevelName)
                .HasMaxLength(50)
                .HasColumnName("access_level_name");
            entity.Property(e => e.MaxPurchaseAmount)
                .HasColumnType("money")
                .HasColumnName("max_purchase_amount");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.VendorId).HasName("PK_vendor");

            entity.ToTable("Vendor");

            entity.Property(e => e.VendorId).HasColumnName("vendor_id");
            entity.Property(e => e.AccountContactId).HasColumnName("account_contact_id");
            entity.Property(e => e.IsConsolidatedBilling).HasColumnName("is_consolidated_billing");
            entity.Property(e => e.IsDirectShip)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("is_direct_ship");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("name");
            entity.Property(e => e.RemitTo).HasColumnName("remit_to");

            entity.HasOne(d => d.AccountContact).WithMany(p => p.Vendors)
                .HasForeignKey(d => d.AccountContactId)
                .HasConstraintName("FK_account_contact");

            entity.HasOne(d => d.RemitToNavigation).WithMany(p => p.Vendors)
                .HasForeignKey(d => d.RemitTo)
                .HasConstraintName("FK_remit_to");
        });

        modelBuilder.Entity<VendorOrderDetail>(entity =>
        {
            entity.HasKey(e => e.VendorOrderDetailId).HasName("PK_Vendor_Order_Detail_1");

            entity.ToTable("Vendor_Order_Detail");

            entity.Property(e => e.VendorOrderDetailId).HasColumnName("vendor_order_detail_id");
            entity.Property(e => e.Amount)
                .HasColumnType("money")
                .HasColumnName("amount");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OrderLineItem).HasColumnName("order_line_item");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.VendorItemNumber)
                .HasMaxLength(200)
                .HasColumnName("vendor_item_number");
            entity.Property(e => e.VendorOrderId).HasColumnName("vendor_order_id");

            entity.HasOne(d => d.VendorOrder).WithMany(p => p.VendorOrderDetails)
                .HasForeignKey(d => d.VendorOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vendor_order_detail_order_id");
        });

        modelBuilder.Entity<VendorOrderHeader>(entity =>
        {
            entity.HasKey(e => e.VendorOrderId).HasName("PK_vendor_order");

            entity.ToTable("Vendor_Order_Header");

            entity.Property(e => e.VendorOrderId).HasColumnName("vendor_order_id");
            entity.Property(e => e.Amount)
                .HasColumnType("money")
                .HasColumnName("amount");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ShipToId).HasColumnName("ship_to_id");
            entity.Property(e => e.VendorId).HasColumnName("vendor_id");
            entity.Property(e => e.VendorOrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("vendor_order_date");

            entity.HasOne(d => d.Order).WithMany(p => p.VendorOrderHeaders)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vendor_order_order_id");

            entity.HasOne(d => d.ShipTo).WithMany(p => p.VendorOrderHeaders)
                .HasForeignKey(d => d.ShipToId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vendor_ship_to");

            entity.HasOne(d => d.Vendor).WithMany(p => p.VendorOrderHeaders)
                .HasForeignKey(d => d.VendorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vendor_order_vendor_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
