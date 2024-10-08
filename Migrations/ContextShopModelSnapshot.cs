﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingList.Context;

#nullable disable

namespace ShoppingList.Migrations
{
    [DbContext(typeof(ContextShop))]
    partial class ContextShopModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BrandProducts", b =>
                {
                    b.Property<int>("BrandsId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.HasKey("BrandsId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("BrandProducts");
                });

            modelBuilder.Entity("ShoppingList.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdListShop")
                        .HasColumnType("int");

                    b.Property<int>("IdSupermarket")
                        .HasColumnType("int");

                    b.Property<string>("NameOfBrand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdListShop");

                    b.HasIndex("IdSupermarket");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("ShoppingList.Entities.ListShop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("ListShop");
                });

            modelBuilder.Entity("ShoppingList.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ShoppingList.Entities.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdListShop")
                        .HasColumnType("int");

                    b.Property<int>("IdSupermarket")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameOfProducts")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdListShop");

                    b.HasIndex("IdSupermarket");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ShoppingList.Entities.Supermarket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdListShop")
                        .HasColumnType("int");

                    b.Property<string>("NameOfSupermarket")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdListShop");

                    b.ToTable("Supermarket");
                });

            modelBuilder.Entity("ShoppingList.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRoles")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BrandProducts", b =>
                {
                    b.HasOne("ShoppingList.Entities.Brand", null)
                        .WithMany()
                        .HasForeignKey("BrandsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoppingList.Entities.Products", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShoppingList.Entities.Brand", b =>
                {
                    b.HasOne("ShoppingList.Entities.ListShop", "ListShops")
                        .WithMany("Brands")
                        .HasForeignKey("IdListShop")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoppingList.Entities.Supermarket", "Supermarkets")
                        .WithMany("Brands")
                        .HasForeignKey("IdSupermarket")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("ListShops");

                    b.Navigation("Supermarkets");
                });

            modelBuilder.Entity("ShoppingList.Entities.ListShop", b =>
                {
                    b.HasOne("ShoppingList.Entities.User", "User")
                        .WithMany("ListShops")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ShoppingList.Entities.Order", b =>
                {
                    b.HasOne("ShoppingList.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ShoppingList.Entities.Products", b =>
                {
                    b.HasOne("ShoppingList.Entities.ListShop", "ListShop")
                        .WithMany("Products")
                        .HasForeignKey("IdListShop")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("ShoppingList.Entities.Supermarket", "Supermarket")
                        .WithMany("Products")
                        .HasForeignKey("IdSupermarket")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("ListShop");

                    b.Navigation("Supermarket");
                });

            modelBuilder.Entity("ShoppingList.Entities.Supermarket", b =>
                {
                    b.HasOne("ShoppingList.Entities.ListShop", "ListShop")
                        .WithMany("Supermarkets")
                        .HasForeignKey("IdListShop")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ListShop");
                });

            modelBuilder.Entity("ShoppingList.Entities.ListShop", b =>
                {
                    b.Navigation("Brands");

                    b.Navigation("Products");

                    b.Navigation("Supermarkets");
                });

            modelBuilder.Entity("ShoppingList.Entities.Supermarket", b =>
                {
                    b.Navigation("Brands");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("ShoppingList.Entities.User", b =>
                {
                    b.Navigation("ListShops");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
