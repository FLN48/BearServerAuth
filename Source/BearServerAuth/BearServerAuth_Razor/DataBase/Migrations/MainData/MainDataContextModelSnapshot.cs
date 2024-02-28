﻿// <auto-generated />
using System;
using BearServerAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BearServerAuth.DataBase.Migrations.MainData
{
    [DbContext(typeof(MainDataContext))]
    partial class MainDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BearServerAuth.Account", b =>
                {
                    b.Property<long>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("AccountId"));

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AccountId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountId = 1L,
                            RoleId = "73ea609c-21de-49bb-929b-00f8937b2ebc",
                            UserId = "dfa355ed-e4a2-45e1-8a6f-6d1316ec8710"
                        });
                });

            modelBuilder.Entity("BearServerAuth.Document", b =>
                {
                    b.Property<long>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("DocumentId"));

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<DateOnly>("DocumentDate")
                        .HasColumnType("date");

                    b.Property<double>("DocumentSimmDiscount")
                        .HasColumnType("double precision");

                    b.Property<double>("DocumentSumm")
                        .HasColumnType("double precision");

                    b.Property<long>("DocumentTypeId")
                        .HasColumnType("bigint");

                    b.HasKey("DocumentId");

                    b.HasIndex("AccountId");

                    b.HasIndex("DocumentTypeId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("BearServerAuth.DocumentType", b =>
                {
                    b.Property<long>("DocumentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("DocumentTypeId"));

                    b.Property<string>("DocumentTypeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("DocumentTypeId");

                    b.ToTable("DocumentTypes");
                });

            modelBuilder.Entity("BearServerAuth.PaymentDocument", b =>
                {
                    b.Property<long>("PaymentDocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("PaymentDocumentId"));

                    b.Property<long>("DocumentId")
                        .HasColumnType("bigint");

                    b.Property<string>("PaymentDocumentCheck")
                        .HasColumnType("text");

                    b.Property<bool>("PaymentDocumentStatus")
                        .HasColumnType("boolean");

                    b.Property<double>("PaymentDocumentSumm")
                        .HasColumnType("double precision");

                    b.Property<double>("PaymentDocumentSummResult")
                        .HasColumnType("double precision");

                    b.Property<long>("PaymentTypeId")
                        .HasColumnType("bigint");

                    b.HasKey("PaymentDocumentId");

                    b.HasIndex("DocumentId");

                    b.HasIndex("PaymentTypeId");

                    b.ToTable("PaymentDocuments");
                });

            modelBuilder.Entity("BearServerAuth.PaymentType", b =>
                {
                    b.Property<long>("PaymentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("PaymentTypeId"));

                    b.Property<string>("PaymentTypeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PaymentTypeId");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("BearServerAuth.Role", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("RoleValue")
                        .HasColumnType("double precision");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = "73ea609c-21de-49bb-929b-00f8937b2ebc",
                            RoleName = "MainAdmin",
                            RoleValue = 0.0
                        },
                        new
                        {
                            RoleId = "ad0e6f3f-072b-474f-baef-f45d63e0afc4",
                            RoleName = "SimpleUser",
                            RoleValue = 10.0
                        });
                });

            modelBuilder.Entity("BearServerAuth.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserAuthor")
                        .HasColumnType("text");

                    b.Property<string>("UserAvatar")
                        .HasColumnType("text");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool?>("UserEmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("UserLogin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserPasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserPhone")
                        .HasColumnType("text");

                    b.Property<bool?>("UserPhoneConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("UserWorking")
                        .HasColumnType("boolean");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = "dfa355ed-e4a2-45e1-8a6f-6d1316ec8710",
                            ConcurrencyStamp = "4de2485c-11cf-4551-a9a6-65f8b514395d",
                            SecurityStamp = "1c7f6b68-0bb2-46f4-a3f0-338098c78333",
                            UserEmail = "mr.camcamcam@mail.ru",
                            UserEmailConfirmed = true,
                            UserLogin = "FиLиN",
                            UserPasswordHash = "AQAAAAEAACcQAAAAEPAsZEempHXA6YFZDtIVyMgYTkhCDA3G10U4DtPt9yMP2Y+SNDWRMUCvA1yArGU1jQ==",
                            UserWorking = true
                        });
                });

            modelBuilder.Entity("BearServerAuth.Account", b =>
                {
                    b.HasOne("BearServerAuth.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BearServerAuth.User", "User")
                        .WithOne("Account")
                        .HasForeignKey("BearServerAuth.Account", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BearServerAuth.Document", b =>
                {
                    b.HasOne("BearServerAuth.Account", "Account")
                        .WithMany("Documents")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BearServerAuth.DocumentType", "DocumentType")
                        .WithMany("Documents")
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("DocumentType");
                });

            modelBuilder.Entity("BearServerAuth.PaymentDocument", b =>
                {
                    b.HasOne("BearServerAuth.Document", "Document")
                        .WithMany("PaymentDocuments")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BearServerAuth.PaymentType", "PaymentType")
                        .WithMany("PaymentDocuments")
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("PaymentType");
                });

            modelBuilder.Entity("BearServerAuth.Account", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("BearServerAuth.Document", b =>
                {
                    b.Navigation("PaymentDocuments");
                });

            modelBuilder.Entity("BearServerAuth.DocumentType", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("BearServerAuth.PaymentType", b =>
                {
                    b.Navigation("PaymentDocuments");
                });

            modelBuilder.Entity("BearServerAuth.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("BearServerAuth.User", b =>
                {
                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}
