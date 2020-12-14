using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Authorization.Dal.Models.Out
{
    public class OutUserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Email { get; set; }
        public string AvatarUrl { get; set; }
    }
}
