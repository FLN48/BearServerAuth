using System;
using System.Collections.Generic;

namespace BearServerAuth
{
    public partial class User
    {
        public long UserId { get; set; }

        public long? AccountId { get; set; }

        public string UserPasswordHash { get; set; } = null!;

        public string UserLogin { get; set; } = null!;

        public string UserEmail { get; set; } = null!;

        public string UserPhone { get; set; } = null!;

        public string UserAuthor { get; set; } = null!;

        public bool UserWorking { get; set; }

        public string? UserAvatar { get; set; }

        public virtual Account? Account { get; set; }

        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}