﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ExamenContext))]
    [Migration("20240422123640_FifthMigration")]
    partial class FifthMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApplicationCore.Domain.Artiste", b =>
                {
                    b.Property<int>("ArtisteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArtisteId"));

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nationalite")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArtisteId");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Chanson", b =>
                {
                    b.Property<int>("ChansonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChansonId"));

                    b.Property<int>("ArtisteFK")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateSortie")
                        .HasColumnType("datetime2");

                    b.Property<int>("Duree")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int>("VuesYoutube")
                        .HasColumnType("int");

                    b.Property<int>("styleMusical")
                        .HasColumnType("int");

                    b.HasKey("ChansonId");

                    b.HasIndex("ArtisteFK");

                    b.ToTable("Chansons");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Concert", b =>
                {
                    b.Property<int>("ArtisteFK")
                        .HasColumnType("int");

                    b.Property<int>("FestivalFK")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateConcert")
                        .HasColumnType("datetime2");

                    b.Property<double>("Cachet")
                        .HasColumnType("float");

                    b.Property<int>("Duree")
                        .HasColumnType("int");

                    b.HasKey("ArtisteFK", "FestivalFK", "DateConcert");

                    b.HasIndex("FestivalFK");

                    b.ToTable("Concertes");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Festival", b =>
                {
                    b.Property<int>("FestivalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FestivalId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FestivalId");

                    b.ToTable("Festival");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Chanson", b =>
                {
                    b.HasOne("ApplicationCore.Domain.Artiste", "Artiste")
                        .WithMany("Chansons")
                        .HasForeignKey("ArtisteFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artiste");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Concert", b =>
                {
                    b.HasOne("ApplicationCore.Domain.Artiste", null)
                        .WithMany()
                        .HasForeignKey("ArtisteFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.Domain.Festival", null)
                        .WithMany()
                        .HasForeignKey("FestivalFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApplicationCore.Domain.Artiste", b =>
                {
                    b.Navigation("Chansons");
                });
#pragma warning restore 612, 618
        }
    }
}
