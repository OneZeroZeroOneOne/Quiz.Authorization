using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Authorization.Dal.Models.Out
{
    public class OutUserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? RoleId { get; set; }
    }
}
