using System;
using System.Collections.Generic;

namespace BearServerAuth
{
    public partial class Role
    {
        public long RoleId { get; set; }

        public string RoleName { get; set; } = null!;

        public double RoleValue { get; set; }

        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}