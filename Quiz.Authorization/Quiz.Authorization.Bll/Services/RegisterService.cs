using Microsoft.EntityFrameworkCore;
using Quiz.Authorization.Dal.Contexts;
using Quiz.Authorization.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Authorization.Bll.Services
{
    public class RegisterService
    {
        private MainContext _context;
        public RegisterService(MainContext maincontext, JwtService jwtService)
        {
            _context = maincontext;
        }

        public async Task<User> RegisterClientAdmin(string login, string password, string email)
        {
            Role role = await _context.Role.FirstOrDefaultAsync(x => x.Title == "ClientAdmin");
            User newUser = new User() { RoleId = role.Id };
            await _context.User.AddAsync(newUser);
            await _context.SaveChangesAsync();
            UserSecurity userSecurity = new UserSecurity()
            {
                Login = login,
                Password = password,
                UserId = newUser.Id,
                Email = email
            };
            await _context.UserSecurity.AddAsync(userSecurity);
            await _context.SaveChangesAsync();
            return newUser;

        }

    }
}
