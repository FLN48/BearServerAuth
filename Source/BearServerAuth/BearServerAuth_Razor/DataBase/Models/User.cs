using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BearServerAuth
{
    public partial class User
    {
        [Key]
        public string UserId { get; set; }

        public string UserPasswordHash { get; set; } = null!;

        public string UserLogin { get; set; } = null!;

        public string UserEmail { get; set; } = null!;

        public string? UserPhone { get; set; } = null!;

        public string? UserAuthor { get; set; } = null!;

        public bool UserWorking { get; set; }

        public string? UserAvatar { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public bool? UserEmailConfirmed { get; set; } = null;
        public bool? UserPhoneConfirmed { get; set; } = null;

        public virtual Account? Account { get; set; }

        public void AddSimpleUser(MainDataContext _dbContext)
        {
            string role_guid = _dbContext.Roles.First(r => r.RoleValue == ((double)EnumRoles.SimpleUser)).RoleId;

            _dbContext.Users.Add(this);
            _dbContext.Accounts.Add(new Account() { RoleId = role_guid, UserId = this.UserId });
            _dbContext.SaveChanges();
        }
    }
}