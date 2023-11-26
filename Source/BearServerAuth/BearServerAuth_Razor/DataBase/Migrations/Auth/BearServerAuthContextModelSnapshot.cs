﻿// <auto-generated />
using System;
using BearServerAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BearServerAuth.Migrations.Auth
{
    [DbContext(typeof(BearServerAuthContext))]
    partial class BearServerAuthContextModelSnapshot : ModelSnapshot
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
                        .HasColumnType("bigint")
                        .HasColumnName("account_id");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint")
                        .HasColumnName("role_id");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("AccountId")
                        .HasName("pk_account");

                    b.HasIndex(new[] { "AccountId" }, "account_pk")
                        .IsUnique();

                    b.HasIndex(new[] { "RoleId" }, "account_role_fk");

                    b.HasIndex(new[] { "UserId" }, "user_to_account2_fk");

                    b.ToTable("account", (string)null);
                });

            modelBuilder.Entity("BearServerAuth.Document", b =>
                {
                    b.Property<long>("DocumentId")
                        .HasColumnType("bigint")
                        .HasColumnName("document_id");

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint")
                        .HasColumnName("account_id");

                    b.Property<DateOnly>("DocumentDate")
                        .HasColumnType("date")
                        .HasColumnName("document_date");

                    b.Property<double>("DocumentSimmDiscount")
                        .HasColumnType("double precision")
                        .HasColumnName("document_simm_discount");

                    b.Property<double>("DocumentSumm")
                        .HasColumnType("double precision")
                        .HasColumnName("document_summ");

                    b.Property<long>("DocumentTypeId")
                        .HasColumnType("bigint")
                        .HasColumnName("document_type_id");

                    b.HasKey("DocumentId")
                        .HasName("pk_document");

                    b.HasIndex(new[] { "AccountId" }, "account_to_document_fk");

                    b.HasIndex(new[] { "DocumentId" }, "document_pk")
                        .IsUnique();

                    b.HasIndex(new[] { "DocumentTypeId" }, "document_type_to_document_fk");

                    b.ToTable("document", (string)null);
                });

            modelBuilder.Entity("BearServerAuth.DocumentType", b =>
                {
                    b.Property<long>("DocumentTypeId")
                        .HasColumnType("bigint")
                        .HasColumnName("document_type_id");

                    b.Property<string>("DocumentTypeName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("document_type_name");

                    b.HasKey("DocumentTypeId")
                        .HasName("pk_document_type");

                    b.HasIndex(new[] { "DocumentTypeId" }, "document_type_pk")
                        .IsUnique();

                    b.ToTable("document_type", (string)null);
                });

            modelBuilder.Entity("BearServerAuth.PaymentDocument", b =>
                {
                    b.Property<long>("PaymentDocumentId")
                        .HasColumnType("bigint")
                        .HasColumnName("payment_document_id");

                    b.Property<long>("DocumentId")
                        .HasColumnType("bigint")
                        .HasColumnName("document_id");

                    b.Property<string>("PaymentDocumentCheck")
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)")
                        .HasColumnName("payment_document_check");

                    b.Property<bool>("PaymentDocumentStatus")
                        .HasColumnType("boolean")
                        .HasColumnName("payment_document_status");

                    b.Property<double>("PaymentDocumentSumm")
                        .HasColumnType("double precision")
                        .HasColumnName("payment_document_summ");

                    b.Property<double>("PaymentDocumentSummResult")
                        .HasColumnType("double precision")
                        .HasColumnName("payment_document_summ_result");

                    b.Property<long>("PaymentTypeId")
                        .HasColumnType("bigint")
                        .HasColumnName("payment_type_id");

                    b.HasKey("PaymentDocumentId")
                        .HasName("pk_payment_document");

                    b.HasIndex(new[] { "DocumentId" }, "document_to_paydocument_fk");

                    b.HasIndex(new[] { "PaymentDocumentId" }, "payment_document_pk")
                        .IsUnique();

                    b.HasIndex(new[] { "PaymentTypeId" }, "payment_type_to_paydocument_fk");

                    b.ToTable("payment_document", (string)null);
                });

            modelBuilder.Entity("BearServerAuth.PaymentType", b =>
                {
                    b.Property<long>("PaymentTypeId")
                        .HasColumnType("bigint")
                        .HasColumnName("payment_type_id");

                    b.Property<string>("PaymentTypeName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("payment_type_name");

                    b.HasKey("PaymentTypeId")
                        .HasName("pk_payment_type");

                    b.HasIndex(new[] { "PaymentTypeId" }, "payment_type_pk")
                        .IsUnique();

                    b.ToTable("payment_type", (string)null);
                });

            modelBuilder.Entity("BearServerAuth.Role", b =>
                {
                    b.Property<long>("RoleId")
                        .HasColumnType("bigint")
                        .HasColumnName("role_id");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("role_name");

                    b.Property<double>("RoleValue")
                        .HasColumnType("double precision")
                        .HasColumnName("role_value");

                    b.HasKey("RoleId")
                        .HasName("pk_role");

                    b.HasIndex(new[] { "RoleId" }, "role_pk")
                        .IsUnique();

                    b.ToTable("role", (string)null);
                });

            modelBuilder.Entity("BearServerAuth.User", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.Property<long?>("AccountId")
                        .HasColumnType("bigint")
                        .HasColumnName("account_id");

                    b.Property<string>("UserAuthor")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("user_author");

                    b.Property<string>("UserAvatar")
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)")
                        .HasColumnName("user_avatar");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("user_email");

                    b.Property<string>("UserLogin")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("user_login");

                    b.Property<string>("UserPasswordHash")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("user_password_hash");

                    b.Property<string>("UserPhone")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("user_phone");

                    b.Property<bool>("UserWorking")
                        .HasColumnType("boolean")
                        .HasColumnName("user_working");

                    b.HasKey("UserId")
                        .HasName("pk_user");

                    b.HasIndex(new[] { "UserId" }, "user_pk")
                        .IsUnique();

                    b.HasIndex(new[] { "AccountId" }, "user_to_account_fk");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("BearServerAuth.Account", b =>
                {
                    b.HasOne("BearServerAuth.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_account_account_r_role");

                    b.HasOne("BearServerAuth.User", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_account_user_to_a_user");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BearServerAuth.Document", b =>
                {
                    b.HasOne("BearServerAuth.Account", "Account")
                        .WithMany("Documents")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_document_account_t_account");

                    b.HasOne("BearServerAuth.DocumentType", "DocumentType")
                        .WithMany("Documents")
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_document_document__document");

                    b.Navigation("Account");

                    b.Navigation("DocumentType");
                });

            modelBuilder.Entity("BearServerAuth.PaymentDocument", b =>
                {
                    b.HasOne("BearServerAuth.Document", "Document")
                        .WithMany("PaymentDocuments")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_payment__document__document");

                    b.HasOne("BearServerAuth.PaymentType", "PaymentType")
                        .WithMany("PaymentDocuments")
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_payment__payment_t_payment_");

                    b.Navigation("Document");

                    b.Navigation("PaymentType");
                });

            modelBuilder.Entity("BearServerAuth.User", b =>
                {
                    b.HasOne("BearServerAuth.Account", "Account")
                        .WithMany("Users")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_user_user_to_a_account");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("BearServerAuth.Account", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("Users");
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
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
