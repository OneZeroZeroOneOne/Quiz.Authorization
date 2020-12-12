using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tests.Authorization.Dal.Models.Out;
using Tests.Authorization.Bll.Services;
using Tests.Authorization.Dal.Models;
using System.Net;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Tests.Authorization.Bll.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Tests.Authorization.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;
        private JwtService _jwtService;
        public LoginController(LoginService loginService, JwtService jwtService)
        {
            _loginService = loginService;
            _jwtService = jwtService;
        }
        [HttpGet]
        public async Task<OutAuthorizationViewModel> Login([FromQuery] string login, [FromQuery] string password)
        {
            User user = await _loginService.Authorization(login, password);
            var identity = _jwtService.GetUserIdentity(user.Id, user.Role.Title);
            var jwtToken = _jwtService.GenerateToken(identity);
            return new OutAuthorizationViewModel() { Id = user.Id, RoleName = user.Role.Title, Token = jwtToken };
        }
        

    }
}