using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BearServerAuth
{
    public partial class Role
    {
        [Key]
        public string RoleId { get; set; }

        public string RoleName { get; set; } = null!;

        public double RoleValue { get; set; }

        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}