﻿// <auto-generated />
using System;
using BankingManagmentSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BankingManagmentSystem.Migrations
{
    [DbContext(typeof(BankingManagmentSystemContext))]
    partial class BankingManagmentSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BankingManagmentSystem.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Balance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric")
                        .HasDefaultValue(0m);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CurrencyCode")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("character varying(3)")
                        .HasDefaultValue("USD");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<string>("Number")
                        .HasMaxLength(18)
                        .HasColumnType("character varying(18)");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyCode");

                    b.HasIndex("CustomerId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BankingManagmentSystem.Entities.BmcRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BankingManagmentSystem.Entities.BmcUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .IsUnique()
                        .HasDatabaseName("EmailNameIndex");

                    b.HasIndex("UserName")
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("779f3783-e69a-4265-b92f-188943ed3be8"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c5802e3e-bdca-4f71-a3e1-8aa915684a48",
                            Email = "admin@irocbank.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@IROCBANK.COM",
                            PasswordHash = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b8f04111-b46b-4cf5-81a4-2131de2c8e8f",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("BankingManagmentSystem.Entities.Currency", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Code");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("BankingManagmentSystem.Entities.CurrencyRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CurrencyCode")
                        .IsRequired()
                        .HasColumnType("character varying(3)");

                    b.Property<DateTime>("OnDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Value")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric")
                        .HasDefaultValue(0m);

                    b.HasKey("Id");

                    b.HasIndex("CurrencyCode");

                    b.ToTable("CurrencyRates");
                });

            modelBuilder.Entity("BankingManagmentSystem.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now() at time zone 'utc'");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BankingManagmentSystem.Entities.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Callsite")
                        .HasColumnType("text");

                    b.Property<string>("Exception")
                        .HasColumnType("text");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Logged")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Logger")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("MachineName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("QueryParameters")
                        .HasColumnType("text");

                    b.Property<string>("RequestMethod")
                        .HasColumnType("text");

                    b.Property<string>("Route")
                        .HasColumnType("text");

                    b.Property<string>("UserPermissions")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("BankingManagmentSystem.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Amount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric")
                        .HasDefaultValue(0m);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CurrencyCode")
                        .HasColumnType("character varying(3)");

                    b.Property<int>("CurrencyRateId")
                        .HasColumnType("integer");

                    b.Property<decimal?>("ProcessedValue")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("Processing")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("CurrencyCode");

                    b.HasIndex("CurrencyRateId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("BankingManagmentSystem.Entities.Account", b =>
                {
                    b.HasOne("BankingManagmentSystem.Entities.Currency", "Currency")
                        .WithMany("Accounts")
                        .HasForeignKey("CurrencyCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankingManagmentSystem.Entities.Customer", "Customer")
                        .WithMany("Accounts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BankingManagmentSystem.Entities.CurrencyRate", b =>
                {
                    b.HasOne("BankingManagmentSystem.Entities.Currency", "Currency")
                        .WithMany("CurrencyRates")
                        .HasForeignKey("CurrencyCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("BankingManagmentSystem.Entities.Transaction", b =>
                {
                    b.HasOne("BankingManagmentSystem.Entities.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankingManagmentSystem.Entities.Currency", "Currency")
                        .WithMany("Transactions")
                        .HasForeignKey("CurrencyCode");

                    b.HasOne("BankingManagmentSystem.Entities.CurrencyRate", "CurrencyOnDate")
                        .WithMany("Transactions")
                        .HasForeignKey("CurrencyRateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Currency");

                    b.Navigation("CurrencyOnDate");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("BankingManagmentSystem.Entities.BmcRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("BankingManagmentSystem.Entities.BmcUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("BankingManagmentSystem.Entities.BmcUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("BankingManagmentSystem.Entities.BmcUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("BankingManagmentSystem.Entities.BmcUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BankingManagmentSystem.Entities.Account", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("BankingManagmentSystem.Entities.Currency", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("CurrencyRates");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("BankingManagmentSystem.Entities.CurrencyRate", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("BankingManagmentSystem.Entities.Customer", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
