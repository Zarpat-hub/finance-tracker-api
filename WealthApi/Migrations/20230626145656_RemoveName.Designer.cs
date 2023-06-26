﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WealthApi.Database;

#nullable disable

namespace WealthApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230626145656_RemoveName")]
    partial class RemoveName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WealthApi.Database.Models.AccountConfiguration", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.Property<string>("ConfigurationJson")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Username");

                    b.ToTable("AccountsConfigurations");
                });

            modelBuilder.Entity("WealthApi.Database.Models.TransactionHistory", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.Property<int?>("Category")
                        .HasColumnType("integer");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Username");

                    b.ToTable("TransactionHistories");
                });

            modelBuilder.Entity("WealthApi.Database.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EncryptedPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RegistrationVerificationToken")
                        .HasColumnType("text");

                    b.Property<string>("UserImg")
                        .HasColumnType("text");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WealthApi.Database.Models.AccountConfiguration", b =>
                {
                    b.HasOne("WealthApi.Database.Models.User", "User")
                        .WithMany("AccountsConfigurations")
                        .HasForeignKey("Username")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WealthApi.Database.Models.TransactionHistory", b =>
                {
                    b.HasOne("WealthApi.Database.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Username")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WealthApi.Database.Models.User", b =>
                {
                    b.Navigation("AccountsConfigurations");
                });
#pragma warning restore 612, 618
        }
    }
}
