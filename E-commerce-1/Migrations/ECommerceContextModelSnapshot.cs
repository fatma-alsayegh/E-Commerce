﻿// <auto-generated />
using System;
using E_commerce_1.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace E_commerce_1.Migrations
{
    [DbContext(typeof(ECommerceContext))]
    partial class ECommerceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("E_commerce_1.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Shirts",
                            Icon = "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Category Images\\shirt icon.png",
                            Name = "Shirts"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Pants",
                            Icon = "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Category Images\\pants icon.png",
                            Name = "Pants"
                        },
                        new
                        {
                            Id = 3,
                            Description = "dresses",
                            Icon = "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Category Images\\dress icon.png",
                            Name = "Dress"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Shoes",
                            Icon = "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Category Images\\shoe icon.png",
                            Name = "Shoes"
                        });
                });

            modelBuilder.Entity("E_commerce_1.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sharjah"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dubai"
                        });
                });

            modelBuilder.Entity("E_commerce_1.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductCount")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TotalCost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("E_commerce_1.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 3,
                            Description = "Balenciaga v-neck green dress",
                            Icon = "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Product Images\\Balenciaga dress.jpg",
                            Name = "Balenciaga Dress",
                            Price = "2000"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 4,
                            Description = "Elegant brown business dress shoe",
                            Icon = "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Product Images\\elegant business dress shoe.jpg",
                            Name = "Dress Shoes",
                            Price = "200"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 4,
                            Description = "Hermes black noir heel sandal",
                            Icon = "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Product Images\\hermes black noir oasis heel sandal.jpg",
                            Name = "Hermes Noir Sandal",
                            Price = "500"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "Louis Vuitton Destroyed Carpenter Denim Pants",
                            Icon = "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Product Images\\Louis vuitton Destroyed Carpenter denim pants.jpg",
                            Name = "Louis Vuitton Denim Pants",
                            Price = "60"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Description = "Blue Gucci Shirt",
                            Icon = "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Product Images\\men gucci shirt.jpg",
                            Name = "Gucci Shirt",
                            Price = "800"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 4,
                            Description = "Nike Winflo 8 Road Running shoes",
                            Icon = "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Product Images\\nike winflo 8 mens road running shoes.jpg",
                            Name = "Nike Road Running shoes",
                            Price = "300"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 1,
                            Description = "Gucci Brown Long Sleeve Shirt",
                            Icon = "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Product Images\\women gucci shirt.jpg",
                            Name = "Gucci Long Sleeve Shirt",
                            Price = "300"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 1,
                            Description = "Zara Greeb Long Sleeve Shirt",
                            Icon = "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Product Images\\zara shirt.jpg",
                            Name = "Zara Long Sleeve Shirt",
                            Price = "150"
                        });
                });

            modelBuilder.Entity("E_commerce_1.Product_Order", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("Product_Orders");
                });

            modelBuilder.Entity("E_commerce_1.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Responsible for adding, editing, deleting of products and products’ categories",
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Can add products to their shopping carts and submit purchasing orders",
                            Name = "Customer"
                        });
                });

            modelBuilder.Entity("E_commerce_1.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 20,
                            Email = "admin@emaratech.ae",
                            FirstName = "Admin",
                            LastName = "Admin",
                            LocationId = 1,
                            Mobile = "0501234567",
                            Password = "123"
                        },
                        new
                        {
                            Id = 2,
                            Age = 22,
                            Email = "fatma@emaratech.ae",
                            FirstName = "Fatma",
                            LastName = "AlSayegh",
                            LocationId = 2,
                            Mobile = "0501234567",
                            Password = "123"
                        },
                        new
                        {
                            Id = 3,
                            Age = 22,
                            Email = "customer@emaratech.ae",
                            FirstName = "Customer",
                            LastName = "Customer",
                            LocationId = 2,
                            Mobile = "0501234567",
                            Password = "123"
                        });
                });

            modelBuilder.Entity("E_commerce_1.User_Role", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("User_Roles");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 3,
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("E_commerce_1.Order", b =>
                {
                    b.HasOne("E_commerce_1.Product", null)
                        .WithMany("Order")
                        .HasForeignKey("ProductId");

                    b.HasOne("E_commerce_1.User", "Users")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("E_commerce_1.Product", b =>
                {
                    b.HasOne("E_commerce_1.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("E_commerce_1.Product_Order", b =>
                {
                    b.HasOne("E_commerce_1.Order", "Order")
                        .WithMany("Product_Orders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_commerce_1.Product", "Product")
                        .WithMany("Product_Orders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("E_commerce_1.User", b =>
                {
                    b.HasOne("E_commerce_1.Location", "Location")
                        .WithMany("Users")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("E_commerce_1.User_Role", b =>
                {
                    b.HasOne("E_commerce_1.Role", "Role")
                        .WithMany("User_Roles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_commerce_1.User", "User")
                        .WithMany("User_Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
