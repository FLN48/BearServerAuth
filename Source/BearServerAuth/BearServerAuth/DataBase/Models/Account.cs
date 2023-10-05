using System;
using System.Collections.Generic;

namespace BearServerAuth
{
    public partial class Account
    {
        public long AccountId { get; set; }

        public long UserId { get; set; }

        public long RoleId { get; set; }

        public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

        public virtual Role Role { get; set; } = null!;

        public virtual User User { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}