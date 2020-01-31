﻿// <auto-generated />
using System;
using InventoryManagement.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InventoryManagement.Migrations
{
    [DbContext(typeof(InventoryManagementContext))]
    [Migration("20200129032832_OwnsMany")]
    partial class OwnsMany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InventoryManagement.Models.Bin", b =>
                {
                    b.Property<int>("BinID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BinName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BinID");

                    b.HasAlternateKey("BinName");

                    b.ToTable("Bins");
                });

            modelBuilder.Entity("InventoryManagement.Models.Inventory", b =>
                {
                    b.Property<int>("InventoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BinID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("QTY")
                        .HasColumnType("int");

                    b.Property<string>("UniqInventory")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("InventoryID");

                    b.HasAlternateKey("UniqInventory");

                    b.HasIndex("BinID");

                    b.HasIndex("ProductID");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("InventoryManagement.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOrdered")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrderID");

                    b.HasAlternateKey("OrderNumber");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("InventoryManagement.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ProductID");

                    b.HasAlternateKey("SKU");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("InventoryManagement.Models.Inventory", b =>
                {
                    b.HasOne("InventoryManagement.Models.Bin", "Bin")
                        .WithMany("Inventory")
                        .HasForeignKey("BinID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventoryManagement.Models.Product", "Product")
                        .WithMany("Inventory")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InventoryManagement.Models.Order", b =>
                {
                    b.OwnsMany("InventoryManagement.Models.OrderLine", "OrderLines", b1 =>
                        {
                            b1.Property<int>("OrderLineID")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("OrderID")
                                .HasColumnType("int");

                            b1.Property<int>("ProductID")
                                .HasColumnType("int");

                            b1.Property<int>("QTY")
                                .HasColumnType("int");

                            b1.HasKey("OrderLineID");

                            b1.HasIndex("OrderID");

                            b1.HasIndex("ProductID");

                            b1.ToTable("OrderLines");

                            b1.WithOwner("Order")
                                .HasForeignKey("OrderID");

                            b1.HasOne("InventoryManagement.Models.Product", "Product")
                                .WithMany()
                                .HasForeignKey("ProductID")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();
                        });
                });
#pragma warning restore 612, 618
        }
    }
}