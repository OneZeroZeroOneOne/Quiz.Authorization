using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz.Authorization.Bll.Services;
using Quiz.Authorization.Dal.Models;
using Quiz.Authorization.Dal.Models.Out;

namespace Quiz.Authorization.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private RegisterService _registerService;
        private JwtService _jwtService;
        public RegisterController(RegisterService registerService, JwtService jwtService)
        {
            _registerService = registerService;
            _jwtService = jwtService;
        }
        [Route("ClientAdmin")]
        [HttpGet]
        public async Task<OutAuthorizationViewModel> RegisterClientAdmin([FromQuery] string login, string password, string email)
        {
            User newUser = await _registerService.RegisterClientAdmin(login, password, email);
            var identity = _jwtService.GetUserIdentity(newUser.UserSecurity.Login, newUser.Role.Title);
            var jwtToken = _jwtService.GenerateToken(identity);
            return new OutAuthorizationViewModel() { Id = newUser.Id, RoleName = newUser.Role.Title, Token = jwtToken };
        }
    }
}