﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniECommerce.Persistence;

#nullable disable

namespace MiniECommerce.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241222164929_seedData")]
    partial class seedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MiniECommerce.Domain.Baskets.Basket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Baskets.BasketItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BasketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.HasIndex("ProductId");

                    b.ToTable("BasketItems");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Orders.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BasketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Orders.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("91b9889d-2019-4e5e-9c89-f0010c9b6e93"),
                            CreatedDate = new DateTime(2024, 12, 22, 19, 49, 28, 668, DateTimeKind.Local).AddTicks(3156),
                            Name = "Laptop",
                            Price = 50000m,
                            Stock = 10
                        },
                        new
                        {
                            Id = new Guid("2528a868-07b4-4d26-b96a-b0cb18e0bd05"),
                            CreatedDate = new DateTime(2024, 12, 22, 19, 49, 28, 668, DateTimeKind.Local).AddTicks(3471),
                            Name = "Telefon",
                            Price = 20000m,
                            Stock = 12
                        },
                        new
                        {
                            Id = new Guid("30a8e2ad-eda9-4c4a-b3dd-081624f67d30"),
                            CreatedDate = new DateTime(2024, 12, 22, 19, 49, 28, 668, DateTimeKind.Local).AddTicks(3481),
                            Name = "Tablet",
                            Price = 8000m,
                            Stock = 7
                        });
                });

            modelBuilder.Entity("MiniECommerce.Domain.Users.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("MiniECommerce.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PWHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PWSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7423cc82-b04f-4055-829f-7992b2d73218"),
                            CreatedDate = new DateTime(2024, 12, 22, 19, 49, 28, 667, DateTimeKind.Local).AddTicks(2226),
                            FirstName = "Admin",
                            LastName = "Admin",
                            PWHash = new byte[] { 214, 48, 148, 32, 58, 199, 86, 153, 231, 140, 108, 205, 162, 136, 148, 106, 76, 177, 18, 241, 240, 140, 223, 39, 253, 109, 95, 26, 141, 44, 64, 210, 120, 229, 247, 170, 191, 247, 83, 175, 213, 199, 192, 57, 41, 99, 230, 90, 65, 84, 126, 71, 72, 67, 148, 224, 166, 250, 129, 105, 111, 152, 27, 84 },
                            PWSalt = new byte[] { 221, 57, 155, 174, 151, 49, 132, 182, 146, 194, 31, 184, 217, 172, 103, 161, 226, 144, 72, 216, 232, 138, 27, 152, 120, 255, 135, 253, 75, 39, 23, 172, 25, 71, 129, 212, 174, 228, 210, 13, 117, 27, 133, 112, 8, 202, 209, 153, 46, 107, 123, 221, 123, 151, 67, 3, 43, 60, 42, 5, 227, 224, 179, 203, 7, 12, 39, 118, 31, 210, 127, 89, 43, 119, 183, 17, 206, 164, 59, 248, 165, 137, 0, 237, 116, 59, 166, 34, 112, 175, 156, 160, 43, 115, 127, 71, 234, 95, 35, 131, 4, 223, 41, 41, 133, 35, 53, 25, 158, 199, 201, 254, 239, 16, 163, 241, 244, 150, 250, 212, 41, 146, 121, 122, 140, 6, 140, 104 },
                            UserName = "admin"
                        },
                        new
                        {
                            Id = new Guid("e6cdc519-0d8c-4c6e-9f01-458fbda440c0"),
                            CreatedDate = new DateTime(2024, 12, 22, 19, 49, 28, 668, DateTimeKind.Local).AddTicks(2364),
                            FirstName = "Test",
                            LastName = "Test",
                            PWHash = new byte[] { 214, 48, 148, 32, 58, 199, 86, 153, 231, 140, 108, 205, 162, 136, 148, 106, 76, 177, 18, 241, 240, 140, 223, 39, 253, 109, 95, 26, 141, 44, 64, 210, 120, 229, 247, 170, 191, 247, 83, 175, 213, 199, 192, 57, 41, 99, 230, 90, 65, 84, 126, 71, 72, 67, 148, 224, 166, 250, 129, 105, 111, 152, 27, 84 },
                            PWSalt = new byte[] { 221, 57, 155, 174, 151, 49, 132, 182, 146, 194, 31, 184, 217, 172, 103, 161, 226, 144, 72, 216, 232, 138, 27, 152, 120, 255, 135, 253, 75, 39, 23, 172, 25, 71, 129, 212, 174, 228, 210, 13, 117, 27, 133, 112, 8, 202, 209, 153, 46, 107, 123, 221, 123, 151, 67, 3, 43, 60, 42, 5, 227, 224, 179, 203, 7, 12, 39, 118, 31, 210, 127, 89, 43, 119, 183, 17, 206, 164, 59, 248, 165, 137, 0, 237, 116, 59, 166, 34, 112, 175, 156, 160, 43, 115, 127, 71, 234, 95, 35, 131, 4, 223, 41, 41, 133, 35, 53, 25, 158, 199, 201, 254, 239, 16, 163, 241, 244, 150, 250, 212, 41, 146, 121, 122, 140, 6, 140, 104 },
                            UserName = "test"
                        });
                });

            modelBuilder.Entity("MiniECommerce.Domain.Users.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("7423cc82-b04f-4055-829f-7992b2d73218"),
                            RoleId = 1
                        },
                        new
                        {
                            UserId = new Guid("e6cdc519-0d8c-4c6e-9f01-458fbda440c0"),
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("MiniECommerce.Domain.Baskets.Basket", b =>
                {
                    b.HasOne("MiniECommerce.Domain.Users.User", "User")
                        .WithMany("Baskets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Baskets.BasketItem", b =>
                {
                    b.HasOne("MiniECommerce.Domain.Baskets.Basket", "Basket")
                        .WithMany("BasketItems")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniECommerce.Domain.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Orders.Order", b =>
                {
                    b.HasOne("MiniECommerce.Domain.Baskets.Basket", "Basket")
                        .WithMany()
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniECommerce.Domain.Users.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Basket");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Orders.OrderItem", b =>
                {
                    b.HasOne("MiniECommerce.Domain.Orders.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniECommerce.Domain.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Users.UserRole", b =>
                {
                    b.HasOne("MiniECommerce.Domain.Users.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniECommerce.Domain.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Baskets.Basket", b =>
                {
                    b.Navigation("BasketItems");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Orders.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("MiniECommerce.Domain.Users.User", b =>
                {
                    b.Navigation("Baskets");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
