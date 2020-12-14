using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tests.Authorization.Bll.Services;
using Tests.Authorization.Dal.Models;
using Tests.Authorization.Dal.Models.In;
using Tests.Authorization.Dal.Models.Out;

namespace Tests.Authorization.Controllers
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
        [HttpPost]
        public async Task<OutAuthorizationViewModel> RegisterClientAdmin([FromBody] InRegisterModel inRegisterModel)
        {
            User newUser = await _registerService.RegisterClientAdmin(inRegisterModel.Login, inRegisterModel.Password, inRegisterModel.Email, inRegisterModel.Name);
            var identity = _jwtService.GetUserIdentity(newUser.Id, newUser.Role.Id);
            var jwtToken = _jwtService.GenerateToken(identity);
            return new OutAuthorizationViewModel() { Id = newUser.Id, RoleName = newUser.Role.Title, Token = jwtToken };
        }
    }
}