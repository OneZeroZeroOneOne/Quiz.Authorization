using Microsoft.IdentityModel.Tokens;
using Quiz.Authorization.Bll.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Authorization.Bll.Services
{
    public class JwtService
    {
        private AuthOptions _authOptions;
        public JwtService(AuthOptions authOptions)
        {
            _authOptions = authOptions;
        }

        public ClaimsIdentity GetUserIdentity(string login, string roleName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, roleName),
            };
            return new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }

        public string GenerateToken(ClaimsIdentity claims)
        {
            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                issuer: _authOptions.ISSUER,
                audience: _authOptions.AUDIENCE,
                notBefore: now,
                claims: claims.Claims,
                expires: now.Add(TimeSpan.FromMinutes(_authOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(_authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return "Bearer " + new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
