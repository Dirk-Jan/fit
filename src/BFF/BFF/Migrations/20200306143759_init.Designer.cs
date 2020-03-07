﻿// <auto-generated />
using System;
using BFF.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BFF.Migrations
{
    [DbContext(typeof(BFFContext))]
    [Migration("20200306143759_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BFF.Models.Oefening", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Omschrijving")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Oefeningen");
                });

            modelBuilder.Entity("BFF.Models.Prestatie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<double>("Gewicht")
                        .HasColumnType("float");

                    b.Property<Guid>("OefeningId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Opmerking")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Set1")
                        .HasColumnType("int");

                    b.Property<int>("Set2")
                        .HasColumnType("int");

                    b.Property<int>("Set3")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OefeningId");

                    b.ToTable("Prestaties");
                });

            modelBuilder.Entity("BFF.Models.Prestatie", b =>
                {
                    b.HasOne("BFF.Models.Oefening", null)
                        .WithMany("Prestaties")
                        .HasForeignKey("OefeningId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
