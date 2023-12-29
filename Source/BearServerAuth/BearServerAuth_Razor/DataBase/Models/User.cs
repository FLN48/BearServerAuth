using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BearServerAuth
{
    public partial class User
    {
        [Key]
        public string UserId { get; set; }

        public long? AccountId { get; set; }

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
    }
}