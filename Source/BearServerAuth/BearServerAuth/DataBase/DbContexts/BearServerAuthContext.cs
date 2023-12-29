using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BearServerAuth 
{

    public partial class MainDataContext : DbContext
    {
        public MainDataContext()
        {
        }

        public MainDataContext(DbContextOptions<MainDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<Document> Documents { get; set; }

        public virtual DbSet<DocumentType> DocumentTypes { get; set; }

        public virtual DbSet<PaymentDocument> PaymentDocuments { get; set; }

        public virtual DbSet<PaymentType> PaymentTypes { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Bear_ServerAuth;Username=postgres;Password=Q12werty");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccountId).HasName("pk_account");

                entity.ToTable("account");

                entity.HasIndex(e => e.AccountId, "account_pk").IsUnique();

                entity.HasIndex(e => e.RoleId, "account_role_fk");

                entity.HasIndex(e => e.UserId, "user_to_account2_fk");

                entity.Property(e => e.AccountId)
                    .ValueGeneratedNever()
                    .HasColumnName("account_id");
                entity.Property(e => e.RoleId).HasColumnName("role_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_account_account_r_role");

                entity.HasOne(d => d.User).WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_account_user_to_a_user");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(e => e.DocumentId).HasName("pk_document");

                entity.ToTable("document");

                entity.HasIndex(e => e.AccountId, "account_to_document_fk");

                entity.HasIndex(e => e.DocumentId, "document_pk").IsUnique();

                entity.HasIndex(e => e.DocumentTypeId, "document_type_to_document_fk");

                entity.Property(e => e.DocumentId)
                    .ValueGeneratedNever()
                    .HasColumnName("document_id");
                entity.Property(e => e.AccountId).HasColumnName("account_id");
                entity.Property(e => e.DocumentDate).HasColumnName("document_date");
                entity.Property(e => e.DocumentSimmDiscount).HasColumnName("document_simm_discount");
                entity.Property(e => e.DocumentSumm).HasColumnName("document_summ");
                entity.Property(e => e.DocumentTypeId).HasColumnName("document_type_id");

                entity.HasOne(d => d.Account).WithMany(p => p.Documents)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_document_account_t_account");

                entity.HasOne(d => d.DocumentType).WithMany(p => p.Documents)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_document_document__document");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.HasKey(e => e.DocumentTypeId).HasName("pk_document_type");

                entity.ToTable("document_type");

                entity.HasIndex(e => e.DocumentTypeId, "document_type_pk").IsUnique();

                entity.Property(e => e.DocumentTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("document_type_id");
                entity.Property(e => e.DocumentTypeName)
                    .HasMaxLength(500)
                    .HasColumnName("document_type_name");
            });

            modelBuilder.Entity<PaymentDocument>(entity =>
            {
                entity.HasKey(e => e.PaymentDocumentId).HasName("pk_payment_document");

                entity.ToTable("payment_document");

                entity.HasIndex(e => e.DocumentId, "document_to_paydocument_fk");

                entity.HasIndex(e => e.PaymentDocumentId, "payment_document_pk").IsUnique();

                entity.HasIndex(e => e.PaymentTypeId, "payment_type_to_paydocument_fk");

                entity.Property(e => e.PaymentDocumentId)
                    .ValueGeneratedNever()
                    .HasColumnName("payment_document_id");
                entity.Property(e => e.DocumentId).HasColumnName("document_id");
                entity.Property(e => e.PaymentDocumentCheck)
                    .HasMaxLength(5000)
                    .HasColumnName("payment_document_check");
                entity.Property(e => e.PaymentDocumentStatus).HasColumnName("payment_document_status");
                entity.Property(e => e.PaymentDocumentSumm).HasColumnName("payment_document_summ");
                entity.Property(e => e.PaymentDocumentSummResult).HasColumnName("payment_document_summ_result");
                entity.Property(e => e.PaymentTypeId).HasColumnName("payment_type_id");

                entity.HasOne(d => d.Document).WithMany(p => p.PaymentDocuments)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_payment__document__document");

                entity.HasOne(d => d.PaymentType).WithMany(p => p.PaymentDocuments)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_payment__payment_t_payment_");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.HasKey(e => e.PaymentTypeId).HasName("pk_payment_type");

                entity.ToTable("payment_type");

                entity.HasIndex(e => e.PaymentTypeId, "payment_type_pk").IsUnique();

                entity.Property(e => e.PaymentTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("payment_type_id");
                entity.Property(e => e.PaymentTypeName)
                    .HasMaxLength(500)
                    .HasColumnName("payment_type_name");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId).HasName("pk_role");

                entity.ToTable("role");

                entity.HasIndex(e => e.RoleId, "role_pk").IsUnique();

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("role_id");
                entity.Property(e => e.RoleName)
                    .HasMaxLength(500)
                    .HasColumnName("role_name");
                entity.Property(e => e.RoleValue).HasColumnName("role_value");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId).HasName("pk_user");

                entity.ToTable("user");

                entity.HasIndex(e => e.UserId, "user_pk").IsUnique();

                entity.HasIndex(e => e.AccountId, "user_to_account_fk");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");
                entity.Property(e => e.AccountId).HasColumnName("account_id");
                entity.Property(e => e.UserAuthor)
                    .HasMaxLength(300)
                    .HasColumnName("user_author");
                entity.Property(e => e.UserAvatar)
                    .HasMaxLength(5000)
                    .HasColumnName("user_avatar");
                entity.Property(e => e.UserEmail)
                    .HasMaxLength(500)
                    .HasColumnName("user_email");
                entity.Property(e => e.UserLogin)
                    .HasMaxLength(500)
                    .HasColumnName("user_login");
                entity.Property(e => e.UserPasswordHash)
                    .HasMaxLength(500)
                    .HasColumnName("user_password_hash");
                entity.Property(e => e.UserPhone)
                    .HasMaxLength(100)
                    .HasColumnName("user_phone");
                entity.Property(e => e.UserWorking).HasColumnName("user_working");

                entity.HasOne(d => d.Account).WithMany(p => p.Users)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_user_user_to_a_account");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}