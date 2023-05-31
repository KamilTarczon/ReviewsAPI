﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReviewsAPI.Data;

#nullable disable

namespace ReviewsAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230527204024_FifhtMigrations")]
    partial class FifhtMigrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReviewsAPI.Models.Drink", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Drinks");
                });

            modelBuilder.Entity("ReviewsAPI.Models.Review", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("Drinkid")
                        .HasColumnType("int");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<int?>("Reviewerid")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Drinkid");

                    b.HasIndex("Reviewerid");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("ReviewsAPI.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("DrinkId")
                        .HasColumnType("int");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReviewId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Reviewers");
                });

            modelBuilder.Entity("ReviewsAPI.Models.Review", b =>
                {
                    b.HasOne("ReviewsAPI.Models.Drink", "Drink")
                        .WithMany("Review")
                        .HasForeignKey("Drinkid");

                    b.HasOne("ReviewsAPI.Models.User", "User")
                        .WithMany("Review")
                        .HasForeignKey("Reviewerid");

                    b.Navigation("Drink");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ReviewsAPI.Models.Drink", b =>
                {
                    b.Navigation("Review");
                });

            modelBuilder.Entity("ReviewsAPI.Models.User", b =>
                {
                    b.Navigation("Review");
                });
#pragma warning restore 612, 618
        }
    }
}
