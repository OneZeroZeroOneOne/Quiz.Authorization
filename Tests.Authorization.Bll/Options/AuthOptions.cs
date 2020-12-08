using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Authorization.Bll.Options
{
    public class AuthOptions
    {
        public string ISSUER = "iliapestov"; // издатель токена
        public string AUDIENCE = "iliapestov"; // потребитель токена
        public string KEY = "mysupersecret_secretkey!321";   // ключ для шифрации
        public int LIFETIME = 3600; // время жизни токена - 1 час

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
