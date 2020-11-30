using System;
using System.Collections.Generic;

#nullable disable

namespace Quiz.Authorization.Dal.Models
{
    public partial class UserSecurity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }

        public virtual User User { get; set; }
    }
}
