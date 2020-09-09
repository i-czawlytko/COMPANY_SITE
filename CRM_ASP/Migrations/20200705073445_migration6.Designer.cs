﻿// <auto-generated />
using System;
using CRM_ASP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CRM_ASP.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200705073445_migration6")]
    partial class migration6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CRM_MODEL_LIB.Article", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("author");

                    b.Property<string>("brief");

                    b.Property<string>("content");

                    b.Property<DateTime>("create_date");

                    b.Property<string>("thread");

                    b.HasKey("id");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("CRM_MODEL_LIB.Bid", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BidStatusId");

                    b.Property<string>("content");

                    b.Property<DateTime>("create_date");

                    b.Property<string>("email");

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.HasIndex("BidStatusId");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("CRM_MODEL_LIB.BidStatus", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description");

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("BidStatus");
                });

            modelBuilder.Entity("CRM_MODEL_LIB.Offer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("content");

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("CRM_MODEL_LIB.Project", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("content");

                    b.Property<string>("name");

                    b.Property<string>("thread");

                    b.HasKey("id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("CRM_MODEL_LIB.Bid", b =>
                {
                    b.HasOne("CRM_MODEL_LIB.BidStatus", "status")
                        .WithMany()
                        .HasForeignKey("BidStatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
