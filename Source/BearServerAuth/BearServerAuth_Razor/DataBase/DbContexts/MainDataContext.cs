using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace BearServerAuth 
{

    public class MainDataContext : DbContext
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
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Bear_ServerAuth;Username=postgres;Password=Q12werty");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Guid guid = Guid.NewGuid();
            string role_admin_guid = Guid.NewGuid().ToString();
            string role_simpleUser_guid = Guid.NewGuid().ToString();
            string user_admin_guid = Guid.NewGuid().ToString();
            string user_admin_security_stamp = Guid.NewGuid().ToString();
            string user_admin_concurency_stamp = Guid.NewGuid().ToString();

            var adminuser = new User
            {
                UserId = user_admin_guid,
                UserLogin = "FиLиN",
                UserEmail = "mr.camcamcam@mail.ru",
                SecurityStamp = user_admin_security_stamp,
                ConcurrencyStamp = user_admin_concurency_stamp,
                UserWorking = true,
                UserEmailConfirmed = true
            };
            adminuser.UserPasswordHash = new PasswordHasher<User>().HashPassword(adminuser, "Q!2werty");
            var AdminRole = new Role
            {
                RoleId = role_admin_guid,
                RoleName = Enum.GetName(typeof(EnumRoles), EnumRoles.MainAdmin)!,
                RoleValue = ((double)EnumRoles.MainAdmin)
            };
            var SimpleUserRole = new Role
            {
                RoleId = role_simpleUser_guid,
                RoleName = Enum.GetName(typeof(EnumRoles), EnumRoles.SimpleUser)!,
                RoleValue = ((double)EnumRoles.SimpleUser)
            };
            var Account = new Account
            { 
                RoleId = role_admin_guid, 
                UserId = user_admin_guid, 
                AccountId = 1 };

            modelBuilder.Entity<User>().HasData(
                    adminuser
            );
            modelBuilder.Entity<Role>().HasData(
                    AdminRole, SimpleUserRole
            );

            modelBuilder.Entity<Account>().HasData(
                    Account
            );
        }
    }
}