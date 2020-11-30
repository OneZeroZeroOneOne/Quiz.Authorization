using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Authorization.Dal.Models.Out
{
    public class OutAuthorizationViewModel
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string RoleName { get; set; }
        public int RoleId { get; set; }
    }
}
