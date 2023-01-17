﻿// <auto-generated />
using System;
using KbstAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KbstAPI.Migrations
{
    [DbContext(typeof(KbstContext))]
    [Migration("20230117082609_M7")]
    partial class M7
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("KbstAPI.Data.Models.Asset", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Properties")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SubType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("KbstAPI.Data.Models.AssetType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Icon")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ParentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("ParentId");

                    b.ToTable("AssetTypes");
                });

            modelBuilder.Entity("KbstAPI.Data.Models.BaseContent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("LayoutSectionId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ParentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("LayoutSectionId");

                    b.HasIndex("ParentId");

                    b.ToTable("BaseContents");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseContent");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("KbstAPI.Data.Models.Label", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("LabelOptionsId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("LabelOptionsId");

                    b.ToTable("Labels");
                });

            modelBuilder.Entity("KbstAPI.Data.Models.LabelOptions", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Alignment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("LabelOptions");
                });

            modelBuilder.Entity("KbstAPI.Data.Models.LayoutConfig", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("LayoutConfigs");
                });

            modelBuilder.Entity("KbstAPI.Data.Models.LayoutSection", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ColumnRatio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("LayoutConfigId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("LayoutConfigId");

                    b.ToTable("LayoutSections");
                });

            modelBuilder.Entity("KbstAPI.Data.Models.ListConfig", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Properties")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Configs");
                });

            modelBuilder.Entity("KbstAPI.Data.Models.Property", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AdditionalValues")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("HasCallback")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("PropertyType")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Properties");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Property");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("KbstAPI.Data.Models.Report", b =>
                {
                    b.Property<int>("ConnectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberOfColumns")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("ConnectionId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("KbstAPI.Data.Models.Schema", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersistencyState")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Properties")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SubType")
                        .HasColumnType("TEXT");

                    b.Property<int>("TemplateId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("TemplateId");

                    b.ToTable("Schemas");
                });

            modelBuilder.Entity("KbstAPI.Data.Models.Group", b =>
                {
                    b.HasBaseType("KbstAPI.Data.Models.BaseContent");

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Gap")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LabelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasIndex("LabelId");

                    b.HasDiscriminator().HasValue("Group");
                });

            modelBuilder.Entity("KbstAPI.Data.Models.PropertyRef", b =>
                {
                    b.HasBaseType("KbstAPI.Data.Models.BaseContent");

                    b.Property<int>("LabelOptionsId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ref")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasIndex("LabelOptionsId");

                    b.HasDiscriminator().HasValue("PropertyRef");
                });

            modelBuilder.Entity("KbstAPI.Data.Models.TextProperty", b =>
                {
                    b.HasBaseType("KbstAPI.Data.Models.Property");

                    b.Property<int>("MaxLength")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MinLength")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Regex")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("TextProperty");
                });

            modelBuilder.Entity("KbstAPI.Data.Models.AssetType", b =>
                {
                    b.HasOne("KbstAPI.Data.Models.AssetType", "Parent")
                        .WithMany("SubTypes")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("KbstAPI.Data.Models.BaseContent", b =>
                {
                    b.HasOne("KbstAPI.Data.Models.LayoutSection", null)
                        .WithMany("Content")
                        .HasForeignKey("LayoutSectionId");

                    b.HasOne("KbstAPI.Data.Models.Group", null)
                        .WithMany("Content")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("KbstAPI.Data.Models.Label", b =>
                {
                    b.HasOne("KbstAPI.Data.Models.LabelOptions", "Options")
                        .WithMany()
                        .HasForeignKey("LabelOptionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Options");
                });

            modelBuilder.Entity("KbstAPI.Data.Models.LayoutSection", b =>
                {
                    b.HasOne("KbstAPI.Data.Models.LayoutConfig", null)
                        .WithMany("Sections")
                        .HasForeignKey("LayoutConfigId");
                });

            modelBuilder.Entity("KbstAPI.Data.Models.Schema", b =>
                {
                    b.HasOne("KbstAPI.Data.Models.LayoutConfig", "Template")
                        .WithMany()
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Template");
                });

            modelBuilder.Entity("KbstAPI.Data.Models.Group", b =>
                {
                    b.HasOne("KbstAPI.Data.Models.Label", "Label")
                        .WithMany()
                        .HasForeignKey("LabelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Label");
                });

            modelBuilder.Entity("KbstAPI.Data.Models.PropertyRef", b =>
                {
                    b.HasOne("KbstAPI.Data.Models.LabelOptions", "LabelOptions")
                        .WithMany()
                        .HasForeignKey("LabelOptionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LabelOptions");
                });

            modelBuilder.Entity("KbstAPI.Data.Models.AssetType", b =>
                {
                    b.Navigation("SubTypes");
                });

            modelBuilder.Entity("KbstAPI.Data.Models.LayoutConfig", b =>
                {
                    b.Navigation("Sections");
                });

            modelBuilder.Entity("KbstAPI.Data.Models.LayoutSection", b =>
                {
                    b.Navigation("Content");
                });

            modelBuilder.Entity("KbstAPI.Data.Models.Group", b =>
                {
                    b.Navigation("Content");
                });
#pragma warning restore 612, 618
        }
    }
}
