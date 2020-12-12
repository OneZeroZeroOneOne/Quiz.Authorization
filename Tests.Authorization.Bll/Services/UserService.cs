using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tests.Authorization.Dal.Contexts;
using Tests.Authorization.Dal.Models;

namespace Tests.Authorization.Bll.Services
{
    public class UserService
    {
        private MainContext _context;
        public UserService(MainContext maincontext, JwtService jwtService)
        {
            _context = maincontext;
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
