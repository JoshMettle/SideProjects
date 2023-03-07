﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SupplyDepotDomain.Model;

#nullable disable

namespace SupplyDepotDomain.Migrations
{
    [DbContext(typeof(SupplyOrdersContext))]
    partial class SupplyOrdersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SupplyDepotDomain.Model.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("location_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"));

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("address1");

                    b.Property<string>("Address2")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("address2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("city");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.Property<bool?>("Obsolete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("Obsolete")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("char(2)")
                        .HasColumnName("state")
                        .IsFixedLength();

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("zip_code");

                    b.HasKey("LocationId")
                        .HasName("PK_location");

                    b.ToTable("Location", (string)null);
                });

            modelBuilder.Entity("SupplyDepotDomain.Model.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("order_detail_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("money")
                        .HasColumnName("amount");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("OrderDetailId")
                        .HasName("PK_Order_Detail_1");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("Order_Detail", (string)null);
                });

            modelBuilder.Entity("SupplyDepotDomain.Model.OrderHeader", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<DateTime?>("OrderDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("order_date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("money")
                        .HasColumnName("total_amount");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("OrderId")
                        .HasName("PK_order_header");

                    b.HasIndex("UserId");

                    b.ToTable("Order_Header", (string)null);
                });

            modelBuilder.Entity("SupplyDepotDomain.Model.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("person_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("last_name");

                    b.Property<bool?>("Obsolete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("Obsolete")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("phone");

                    b.HasKey("PersonId")
                        .HasName("PK_person");

                    b.ToTable("Person", (string)null);
                });

            modelBuilder.Entity("SupplyDepotDomain.Model.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CaseQty")
                        .HasColumnType("int")
                        .HasColumnName("case_qty");

                    b.Property<int?>("MaximumQty")
                        .HasColumnType("int")
                        .HasColumnName("maximum_qty");

                    b.Property<int?>("MinimumQty")
                        .HasColumnType("int")
                        .HasColumnName("minimum_qty");

                    b.Property<bool?>("Obsolete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("Obsolete")
                        .HasDefaultValueSql("((0))");

                    b.Property<decimal>("PricePerCase")
                        .HasColumnType("money")
                        .HasColumnName("price_per_case");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)")
                        .HasColumnName("product_description");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("product_name");

                    b.Property<int?>("ProductType")
                        .HasColumnType("int")
                        .HasColumnName("product_type");

                    b.Property<int>("VendorId")
                        .HasColumnType("int")
                        .HasColumnName("vendor_id");

                    b.Property<string>("VendorProductNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("vendor_product_number");

                    b.HasKey("ProductId")
                        .HasName("PK_product_id");

                    b.HasIndex("ProductType");

                    b.HasIndex(new[] { "VendorId", "VendorProductNumber" }, "UQ_vendor_product")
                        .IsUnique();

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("SupplyDepotDomain.Model.ProductCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("category_name");

                    b.HasKey("CategoryId")
                        .HasName("PK_product_category");

                    b.HasIndex(new[] { "CategoryName" }, "UK_product_category_name")
                        .IsUnique()
                        .HasFilter("[category_name] IS NOT NULL");

                    b.ToTable("Product_Category", (string)null);
                });

            modelBuilder.Entity("SupplyDepotDomain.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<int>("AccessLevel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("access_level")
                        .HasDefaultValueSql("((1))");

                    b.Property<bool?>("Obsolete")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("password");

                    b.Property<int>("PersonId")
                        .HasColumnType("int")
                        .HasColumnName("person_id");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("salt");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("username");

                    b.HasKey("UserId")
                        .HasName("PK_user");

                    b.HasIndex("AccessLevel");

                    b.HasIndex("PersonId");

                    b.HasIndex(new[] { "Username" }, "UQ_username")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("SupplyDepotDomain.Model.UserAccessLevel", b =>
                {
                    b.Property<int>("AccessLevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("access_level_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccessLevelId"));

                    b.Property<string>("AccessLevelName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("access_level_name");

                    b.Property<decimal?>("MaxPurchaseAmount")
                        .HasColumnType("money")
                        .HasColumnName("max_purchase_amount");

                    b.HasKey("AccessLevelId")
                        .HasName("PK_access_level");

                    b.ToTable("User_Access_Level", (string)null);
                });

            modelBuilder.Entity("SupplyDepotDomain.Model.Vendor", b =>
                {
                    b.Property<int>("VendorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("vendor_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VendorId"));

                    b.Property<int?>("AccountContactId")
                        .HasColumnType("int")
                        .HasColumnName("account_contact_id");

                    b.Property<bool>("IsConsolidatedBilling")
                        .HasColumnType("bit")
                        .HasColumnName("is_consolidated_billing");

                    b.Property<bool?>("IsDirectShip")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("is_direct_ship")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("name");

                    b.Property<bool?>("Obsolete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("Obsolete")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("RemitTo")
                        .HasColumnType("int")
                        .HasColumnName("remit_to");

                    b.HasKey("VendorId")
                        .HasName("PK_vendor");

                    b.HasIndex("AccountContactId");

                    b.HasIndex("RemitTo");

                    b.ToTable("Vendor", (string)null);
                });

            modelBuilder.Entity("SupplyDepotDomain.Model.VendorOrderDetail", b =>
                {
                    b.Property<int>("VendorOrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("vendor_order_detail_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VendorOrderDetailId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("money")
                        .HasColumnName("amount");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<int>("OrderLineItem")
                        .HasColumnType("int")
                        .HasColumnName("order_line_item");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<string>("VendorItemNumber")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("vendor_item_number");

                    b.Property<int>("VendorOrderId")
                        .HasColumnType("int")
                        .HasColumnName("vendor_order_id");

                    b.HasKey("VendorOrderDetailId")
                        .HasName("PK_Vendor_Order_Detail_1");

                    b.HasIndex("VendorOrderId");

                    b.ToTable("Vendor_Order_Detail", (string)null);
                });

            modelBuilder.Entity("SupplyDepotDomain.Model.VendorOrderHeader", b =>
                {
                    b.Property<int>("VendorOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("vendor_order_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VendorOrderId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("money")
                        .HasColumnName("amount");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<int>("ShipToId")
                        .HasColumnType("int")
                        .HasColumnName("ship_to_id");

                    b.Property<int>("VendorId")
                        .HasColumnType("int")
                        .HasColumnName("vendor_id");

                    b.Property<DateTime?>("VendorOrderDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("vendor_order_date")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("VendorOrderId")
                        .HasName("PK_vendor_order");

                    b.HasIndex("OrderId");

                    b.HasIndex("ShipToId");

                    b.HasIndex("VendorId");

                    b.ToTable("Vendor_Order_Header", (string)null);
                });

            modelBuilder.Entity("SupplyDepotDomain.Model.OrderDetail", b =>
                {
                    b.HasOne("SupplyDepotDomain.Model.OrderHeader", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("FK_order_detail_order_id");

                    b.HasOne("SupplyDepotDomain.Model.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_order_detail_product");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SupplyDepotDomain.Model.OrderHeader", b =>
                {
                    b.HasOne("SupplyDepotDomain.Model.User", "User")
                        .WithMany("OrderHeaders")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_order_header_user");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SupplyDepotDomain.Model.Product", b =>
                {
                    b.HasOne("SupplyDepotDomain.Model.ProductCategory", "ProductTypeNavigation")
                        .WithMany("Products")
                        .HasForeignKey("ProductType")
                        .HasConstraintName("FK_product_category");

                    b.HasOne("SupplyDepotDomain.Model.Vendor", "Vendor")
                        .WithMany("Products")
                        .HasForeignKey("VendorId")
                        .IsRequired()
                        .HasConstraintName("FK_vendor_id");

                    b.Navigation("ProductTypeNavigation");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("SupplyDepotDomain.Model.User", b =>
                {
                    b.HasOne("SupplyDepotDomain.Model.UserAccessLevel", "AccessLevelNavigation")
                        .WithMany("Users")
                        .HasForeignKey("AccessLevel")
                        .IsRequired()
                        .HasConstraintName("FK_user_access_level");

                    b.HasOne("SupplyDepotDomain.Model.Person", "Person")
                        .WithMany("Users")
                        .HasForeignKey("PersonId")
                        .IsRequired()
                        .HasConstraintName("FK_user_person_id");

                    b.Navigation("AccessLevelNavigation");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("SupplyDepotDomain.Model.Vendor", b =>
                {
                    b.HasOne("SupplyDepotDomain.Model.Person", "AccountContact")
                        .WithMany("Vendors")
                        .HasForeignKey("AccountContactId")
                        .HasConstraintName("FK_account_contact");

                    b.HasOne("SupplyDepotDomain.Model.Location", "RemitToNavigation")
                        .WithMany("Vendors")
                        .HasForeignKey("RemitTo")
                        .HasConstraintName("FK_remit_to");

                    b.Navigation("AccountContact");

                    b.Navigation("RemitToNavigation");
                });

            modelBuilder.Entity("SupplyDepotDomain.Model.VendorOrderDetail", b =>
                {
                    b.HasOne("SupplyDepotDomain.Model.VendorOrderHeader", "VendorOrder")
                        .WithMany("VendorOrderDetails")
                        .HasForeignKey("VendorOrderId")
                        .IsRequired()
                        .HasConstraintName("FK_vendor_order_detail_order_id");

                    b.Navigation("VendorOrder");
                });

            modelBuilder.Entity("SupplyDepotDomain.Model.VendorOrderHeader", b =>
                {
                    b.HasOne("SupplyDepotDomain.Model.OrderHeader", "Order")
                        .WithMany("VendorOrderHeaders")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("FK_vendor_order_order_id");

                    b.HasOne("SupplyDepotDomain.Model.Location", "ShipTo")
                        .WithMany("VendorOrderHeaders")
                        .HasForeignKey("ShipToId")
                        .IsRequired()
                        .HasConstraintName("FK_vendor_ship_to");

                    b.HasOne("SupplyDepotDomain.Model.Vendor", "Vendor")
                        .WithMany("VendorOrderHeaders")
                        .HasForeignKey("VendorId")
                        .IsRequired()
                        .HasConstraintName("FK_vendor_order_vendor_id");

                    b.Navigation("Order");

                    b.Navigation("ShipTo");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("SupplyDepotDomain.Model.Location", b =>
                {
                    b.Navigation("VendorOrderHeaders");

                    b.Navigation("Vendors");
                });

            modelBuilder.Entity("SupplyDepotDomain.Model.OrderHeader", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("VendorOrderHeaders");
                });

            modelBuilder.Entity("SupplyDepotDomain.Model.Person", b =>
                {
                    b.Navigation("Users");

                    b.Navigation("Vendors");
                });

            modelBuilder.Entity("SupplyDepotDomain.Model.Product", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("SupplyDepotDomain.Model.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SupplyDepotDomain.Model.User", b =>
                {
                    b.Navigation("OrderHeaders");
                });

            modelBuilder.Entity("SupplyDepotDomain.Model.UserAccessLevel", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("SupplyDepotDomain.Model.Vendor", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("VendorOrderHeaders");
                });

            modelBuilder.Entity("SupplyDepotDomain.Model.VendorOrderHeader", b =>
                {
                    b.Navigation("VendorOrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
