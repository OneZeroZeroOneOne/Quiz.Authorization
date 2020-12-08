using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Authorization.Dal.Models.In
{
    public class InRegisterModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
