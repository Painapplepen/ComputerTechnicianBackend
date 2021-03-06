// <auto-generated />
using System;
using ComputerTechnicianBackend.Data.EF.SQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ComputerTechnicianBackend.Data.EF.SQL.Migrations
{
    [DbContext(typeof(ComputerTechnicianDbContext))]
    [Migration("20211031083209_UpdatedBasketTable")]
    partial class UpdatedBasketTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.Basket", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("Amount")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.City", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.CreditCard", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CardNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("EpirationDate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.Manufacture", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Manufactures");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ManufactureId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ManufactureId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.OrderProduct", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.PersonalData", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CityId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CreditCardId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PhoneId")
                        .HasColumnType("bigint");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CreditCardId");

                    b.HasIndex("PhoneId");

                    b.ToTable("PersonalDatas");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.Phone", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Phones");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<long>("Cost")
                        .HasColumnType("bigint");

                    b.Property<string>("DriveConfiguration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<long>("MemoryCapacity")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Processor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ProductTypeId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("ScreenDiagonal")
                        .HasColumnType("bigint");

                    b.Property<string>("ScreenResolution")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VidioCard")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.ProductBasket", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BasketId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductBaskets");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.ProductManufacture", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ManufactureId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ManufactureId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductManufactures");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.ProductType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.Request", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.RequestOrder", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<long>("RequestId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("RequestId");

                    b.ToTable("RequestOrders");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.RequestProductManufacture", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductManufactureId")
                        .HasColumnType("bigint");

                    b.Property<long>("RequestId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductManufactureId");

                    b.HasIndex("RequestId");

                    b.ToTable("RequestProductManufactures");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.Supplier", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.SupplierProductManufacture", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<long>("Cost")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductManufactureId")
                        .HasColumnType("bigint");

                    b.Property<long>("SupplierId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductManufactureId");

                    b.HasIndex("SupplierId");

                    b.ToTable("SupplierProductManufactures");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("BasketId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PersonalDataId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonalDataId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Views.PersonalDataView", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CardNumber")
                        .HasColumnType("bigint")
                        .HasColumnName("CardNumber");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("City");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateOfBirth");

                    b.Property<string>("EpirationDate")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EpirationDate");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Phone");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SecondName");

                    b.HasKey("Id");

                    b.ToView("View_PersonalDataView");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Views.UserView", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BasketSize")
                        .HasColumnType("bigint")
                        .HasColumnName("BasketSize");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Role");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UserName");

                    b.HasKey("Id");

                    b.ToView("View_UserView");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.Basket", b =>
                {
                    b.HasOne("ComputerTechnicianBackend.Data.Domain.Models.User", "User")
                        .WithOne("Basket")
                        .HasForeignKey("ComputerTechnicianBackend.Data.Domain.Models.Basket", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.Order", b =>
                {
                    b.HasOne("ComputerTechnicianBackend.Data.Domain.Models.Manufacture", "Manufacture")
                        .WithMany()
                        .HasForeignKey("ManufactureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacture");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.OrderProduct", b =>
                {
                    b.HasOne("ComputerTechnicianBackend.Data.Domain.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComputerTechnicianBackend.Data.Domain.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.PersonalData", b =>
                {
                    b.HasOne("ComputerTechnicianBackend.Data.Domain.Models.City", "Cities")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("ComputerTechnicianBackend.Data.Domain.Models.CreditCard", "CreditCards")
                        .WithMany()
                        .HasForeignKey("CreditCardId");

                    b.HasOne("ComputerTechnicianBackend.Data.Domain.Models.Phone", "Phones")
                        .WithMany()
                        .HasForeignKey("PhoneId");

                    b.Navigation("Cities");

                    b.Navigation("CreditCards");

                    b.Navigation("Phones");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.Product", b =>
                {
                    b.HasOne("ComputerTechnicianBackend.Data.Domain.Models.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.ProductBasket", b =>
                {
                    b.HasOne("ComputerTechnicianBackend.Data.Domain.Models.Basket", "Basket")
                        .WithMany()
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComputerTechnicianBackend.Data.Domain.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.ProductManufacture", b =>
                {
                    b.HasOne("ComputerTechnicianBackend.Data.Domain.Models.Manufacture", "Manufacture")
                        .WithMany()
                        .HasForeignKey("ManufactureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComputerTechnicianBackend.Data.Domain.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacture");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.RequestOrder", b =>
                {
                    b.HasOne("ComputerTechnicianBackend.Data.Domain.Models.Order", "Orders")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComputerTechnicianBackend.Data.Domain.Models.Request", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.RequestProductManufacture", b =>
                {
                    b.HasOne("ComputerTechnicianBackend.Data.Domain.Models.ProductManufacture", "ProductManufacture")
                        .WithMany()
                        .HasForeignKey("ProductManufactureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComputerTechnicianBackend.Data.Domain.Models.Request", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductManufacture");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.SupplierProductManufacture", b =>
                {
                    b.HasOne("ComputerTechnicianBackend.Data.Domain.Models.ProductManufacture", "ProductManufacture")
                        .WithMany()
                        .HasForeignKey("ProductManufactureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComputerTechnicianBackend.Data.Domain.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductManufacture");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.User", b =>
                {
                    b.HasOne("ComputerTechnicianBackend.Data.Domain.Models.PersonalData", "PersonalData")
                        .WithMany()
                        .HasForeignKey("PersonalDataId");

                    b.HasOne("ComputerTechnicianBackend.Data.Domain.Models.Role", "Roles")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalData");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("ComputerTechnicianBackend.Data.Domain.Models.User", b =>
                {
                    b.Navigation("Basket");
                });
#pragma warning restore 612, 618
        }
    }
}
