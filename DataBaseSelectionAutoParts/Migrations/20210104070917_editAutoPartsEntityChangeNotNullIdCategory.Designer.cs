﻿// <auto-generated />
using System;
using DataBaseSelectionAutoParts.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataBaseSelectionAutoParts.Migrations
{
    [DbContext(typeof(AutoPartsContext))]
    [Migration("20210104070917_editAutoPartsEntityChangeNotNullIdCategory")]
    partial class editAutoPartsEntityChangeNotNullIdCategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("DataBaseSelectionAutoParts.Models.AutoParts", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("idCategory")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("properties")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("idCategory");

                    b.ToTable("autoParts");
                });

            modelBuilder.Entity("DataBaseSelectionAutoParts.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("properties")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("DataBaseSelectionAutoParts.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("countries");
                });

            modelBuilder.Entity("DataBaseSelectionAutoParts.Models.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("aboutCompany")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idCountry")
                        .HasColumnType("int");

                    b.Property<byte[]>("imageLogo")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("idCountry");

                    b.ToTable("manufacturers");
                });

            modelBuilder.Entity("DataBaseSelectionAutoParts.Models.AutoParts", b =>
                {
                    b.HasOne("DataBaseSelectionAutoParts.Models.Category", "category")
                        .WithMany("AutoParts")
                        .HasForeignKey("idCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("DataBaseSelectionAutoParts.Models.Category", b =>
                {
                    b.HasOne("DataBaseSelectionAutoParts.Models.Category", "ParentCategory")
                        .WithMany("ChildrenCategories")
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("DataBaseSelectionAutoParts.Models.Manufacturer", b =>
                {
                    b.HasOne("DataBaseSelectionAutoParts.Models.Country", "country")
                        .WithMany("manufacturers")
                        .HasForeignKey("idCountry")
                        .HasConstraintName("FK_ManufacturerCountry")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("country");
                });

            modelBuilder.Entity("DataBaseSelectionAutoParts.Models.Category", b =>
                {
                    b.Navigation("AutoParts");

                    b.Navigation("ChildrenCategories");
                });

            modelBuilder.Entity("DataBaseSelectionAutoParts.Models.Country", b =>
                {
                    b.Navigation("manufacturers");
                });
#pragma warning restore 612, 618
        }
    }
}
