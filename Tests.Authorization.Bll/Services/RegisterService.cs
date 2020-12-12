using Microsoft.EntityFrameworkCore;
using Tests.Authorization.Dal.Contexts;
using Tests.Authorization.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Authorization.Bll.Services
{
    public class RegisterService
    {
        private MainContext _context;
        public RegisterService(MainContext maincontext)
        {
            _context = maincontext;
        }

        public async Task<User> RegisterClientAdmin(string login, string password, string email, string name)
        {
            Role role = await _context.Role.FirstOrDefaultAsync(x => x.Title == "ClientAdmin");
            User newUser = new User() { RoleId = role.Id, Name = name, CreateDateTime = DateTime.Now};
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
