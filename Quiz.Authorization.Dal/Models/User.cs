using System;
using System.Collections.Generic;

#nullable disable

namespace Quiz.Authorization.Dal.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public DateTime? CreatedDateTime { get; set; }

        public virtual Role Role { get; set; }
        public virtual UserSecurity UserSecurity { get; set; }
    }
}
